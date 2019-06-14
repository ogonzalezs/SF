namespace AT.Middleware.Service
{
    using System;
    using AT.Middleware.Service.Interface;
    using log4net;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Json;
    using AT.Model.View;
    using System.IO;
    using AT.Middleware.Business;
    using System.ServiceModel;

    using AT.Middleware.Business;

    using System.Collections.Generic;
    using System.ServiceModel.Activation;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name
    //       "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc
    //       or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Client : IClient, IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Business.Client oClient = null;

        public Client()
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                oClient = Authorization.ClientAuthorization.oClient;
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a client. </summary>
        ///
        /// <remarks>   Arovario, 23-09-2017. </remarks>
        ///
        /// <param name="CardCode"> The card code. </param>
        ///
        /// <returns>   The client. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetClient(string CardCode)
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Customers>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oClient.GetOCRD(CardCode);

                    data.WriteObject(StrMem, Result);
                    StrMem.Position = 0;

                    using (StreamReader StrOut = new StreamReader(StrMem))
                    {
                        Resp = StrOut.ReadToEnd();
                    }
                }
                return Resp;
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets client all. </summary>
        ///
        /// <remarks>   Arovario, 23-09-2017. </remarks>
        ///
        /// <returns>   The client all. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetClientAll()
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Customers>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oClient.GetOCRD();

                    data.WriteObject(StrMem, Result);
                    StrMem.Position = 0;

                    using (StreamReader StrOut = new StreamReader(StrMem))
                    {
                        Resp = StrOut.ReadToEnd();
                    }
                }
                return Resp;
            }
            catch (FaultException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
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
                    if (oClient != null)
                        oClient = null;
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