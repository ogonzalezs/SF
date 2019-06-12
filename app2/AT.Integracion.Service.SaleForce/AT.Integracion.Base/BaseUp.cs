using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AT.Integracion.Business;
namespace AT.Integracion.Base
{
    public class BaseUp: IDisposable
    {
        private static readonly ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseUp()
        {

        }

        public Dictionary<string, string> EjecutarServicioOrders()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.InfoFormat("Se inicia proceso de Consulta a base de datos, con el metodo: {0}",
                          System.Reflection.MethodBase.GetCurrentMethod().Name);

            Dictionary<string, string> Procesado = new Dictionary<string, string>();

            try
            {
                using (Business.BaseUp _Business = new Business.BaseUp())
                {
                    Dictionary<string, string> Process = _Business.ObtenerData();

                    if (Process.Count > 0)
                    {
                        if (!Process.ContainsKey("0"))
                        {
                            string message = string.Empty;
                            Process.ToList().ForEach(delegate (KeyValuePair<string, string> item)
                            { message = message + item.Value; });

                            Procesado.Add("Error",
                              String.Format("Se ha generado un error en el proceso para subir los datos al repositorio principal, el error se basa en: {0}",
                               message));
                        }
                        else
                        {
                            Procesado.Add("OK","Se ha realizado el proceso de generar de Ordenes en la base de datos.");

                            log.Info("Se ha realizado el proceso de generar de Ordenes en la base de datos");
                        }
                    }
                    else
                    {
                        Procesado.Add("OK", "Se ha realizado el proceso de generar de Ordenes en la base de datos.");

                        log.Info("Se ha realizado el proceso de generar de Ordenes en la base de datos");
                    }
                    return Procesado;
                };
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

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged
        // resources. ~Base() { // Do not change this code. Put cleanup code in Dispose(bool
        // disposing) above. Dispose(false); }

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
