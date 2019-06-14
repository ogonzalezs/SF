namespace AT.Middleware.Business
{
    using AT.Model.View;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AT.Middleware.Data;

    public class Client : IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Data.Client oClient = null;


        public Client()
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                oClient = new Data.Client();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Customers> GetOCRD(long IdEmpresa)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                                System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                return oClient.GetCustomer(IdEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Customers> GetOCRD(long IdEmpresa, string CardCode)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                                System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                return oClient.GetCustomer(IdEmpresa,CardCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected void Dispose(bool disposing)
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
        //       unmanaged resources. ~DocumentoReferenciado() { // Do not change this code. Put
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