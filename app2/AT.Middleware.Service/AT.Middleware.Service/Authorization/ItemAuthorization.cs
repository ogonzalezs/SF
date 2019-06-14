namespace AT.Middleware.Service.Authorization
{
    using AT.Middleware.Business;
    using log4net;
    using System;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    public class ItemAuthorization : ServiceAuthorizationManager, IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Item oItem = null;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Comprueba la autorización para el contexto especificado de la operación en función de la
        /// evaluación de la directiva predeterminada.
        /// </summary>
        ///
        /// <remarks>   Arovario, 22-09-2017. </remarks>
        ///
        /// <exception cref="WebFaultException">    Thrown when a Web Fault error condition occurs. </exception>
        ///
        /// <param name="operationContext"> <see cref="T:System.ServiceModel.OperationContext" /> de la
        ///                                 solicitud actual de autorización. </param>
        ///
        /// <returns>
        /// true si se concede el acceso; si no, false.De manera predeterminada, es true.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

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

                if ((user.Name.Length == 0 || user.Password.Length == 0))
                    throw new WebFaultException(HttpStatusCode.Unauthorized);

                try
                {
                    if (oItem == null)
                    {
                        oItem = new Item(Properties.Settings.Default.Server,
                        Properties.Settings.Default.CompanyDB, Properties.Settings.Default.DbUserName,
                        Properties.Settings.Default.DbPassword,
                        Properties.Settings.Default.LicenseServer, user.Name, user.Password);
                    }

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                //No authorization header was provided, so challenge the Item to provide before proceeding:
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic realm=\"Middleware\"");
                //Throw an exception with the associated HTTP status code equivalent to HTTP status 401
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free
        //       unmanaged resources. ~ServiceAuthorization() { // Do not change this code. Put
        // cleanup code in Dispose(bool disposing) above. Dispose(false); }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above. GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}