namespace AT.Middleware.Service
{
    using System;
    using System.ServiceModel.Activation;
    using System.Web.Routing;
    using System.Web;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            WebServiceHostFactory factory = new WebServiceHostFactory();
            RouteTable.Routes.Add(new ServiceRoute("Client", factory, typeof(Client)));
            RouteTable.Routes.Add(new ServiceRoute("Status", factory, typeof(Status)));
            RouteTable.Routes.Add(new ServiceRoute("Item", factory, typeof(Item)));
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{
        //}

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //}

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{
        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //}

        //protected void Session_End(object sender, EventArgs e)
        //{
        //}

        //protected void Application_End(object sender, EventArgs e)
        //{
        //}
    }
}