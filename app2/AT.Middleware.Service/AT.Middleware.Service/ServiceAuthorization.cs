namespace AT.Middleware.Service
{
    using AT.Middleware.Business;
    using System;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    public class ServiceAuthorization : ServiceAuthorizationManager
    {
        public Base Business = new Base();

        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            //Extract the Authorization header, and parse out the credentials converting the Base64 string:
            var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            if ((authHeader != null) && (authHeader != string.Empty))
            {
                var svcCredentials = System.Text.ASCIIEncoding.ASCII
                    .GetString(Convert.FromBase64String(authHeader.Substring(6)))
                    .Split(':');

                var user = new
                {
                    Name = svcCredentials[0],
                    Password = svcCredentials[1]
                };

                if (user.Name.Length == 0)
                    throw new WebFaultException(HttpStatusCode.Unauthorized);

                if (user.Password.Length == 0)
                    throw new WebFaultException(HttpStatusCode.Unauthorized);
                try
                {
                    return Business.Connect(Properties.Settings.Default.Server, Properties.Settings.Default.CompanyDB,
                        Properties.Settings.Default.DbUserName, Properties.Settings.Default.DbPassword,
                        Properties.Settings.Default.LicenseServer, user.Name, user.Password);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //No authorization header was provided, so challenge the client to provide before proceeding:
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"MiddlewareSAP\"");
                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }
    }
}