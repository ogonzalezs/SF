namespace AT.Middleware.Business
{
    using AT.Model.View;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Item : IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Data.Item oItem = null;


        public Item()
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                oItem = new Data.Item();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Items> GetItem(long IdEmpresa)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                                System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                return oItem.GetItem(IdEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Items> GetItem(long IdEmpresa,string ItemCode)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                                System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                return oItem.GetItem(ItemCode,  IdEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<ItemPrices> GetItemByPriceList(long IdEmpresa,string ItemCode, string PriceList)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                                System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {
                return oItem.GetItemByPriceList(ItemCode, IdEmpresa, PriceList);
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
                    if (oItem != null)
                        oItem = null;

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