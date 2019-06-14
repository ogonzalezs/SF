namespace AT.Middleware.Data
{
    using AT.Model.View;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class Item : IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Item()
        {
        }

        public List<Items> GetItem(long IdEmpresa)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            List<Items> Result = new List<Items>();

            try
            {
                using (var context = new SALESFORCESEntities())
                {
                    Result = context.t_Item.Where(w => w.IdCompany.Equals(IdEmpresa)).Select(s=> new Items {
                         
                    }).ToList();
                }

                return Result;
            }
            catch (COMException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public List<Items> GetItem(string ItemCode, long IdEmpresa)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            List<Items> Result = new List<Items>();

            try
            {
                using (var context = new SALESFORCESEntities())
                {
                    Result = context.t_Item.Where(w => w.ItemCode.Equals(ItemCode) && w.IdCompany.Equals(IdEmpresa)).Select(s => new Items
                    {

                    }).ToList();
                }

                return Result;
            }
            catch (COMException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public List<ItemPrices> GetItemByPriceList(string ItemCode, long IdEmpresa, string ListPrice)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            List<ItemPrices> Result = new List<ItemPrices>();

            try
            {
                using (var context = new SALESFORCESEntities())
                {
                    Result = context.t_ItemPrice.Where(w => w.ItemCode.Equals(ItemCode) &&
                    w.IdCompany.Equals(IdEmpresa) &&
                    w.PriceList.Equals(ListPrice)).Select(s=> new ItemPrices() {
                         ItemCode = s.ItemCode,
                          IdCompany = s.IdCompany,
                           Price = s.Price,
                            PriceList = s.PriceList,
                             DateUp = s.DateUp,
                              DateDown = s.DateDown
                    }).ToList();
                }

                return Result;
            }
            catch (COMException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
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