using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Integracion.Base
{
    public class BaseDown:IDisposable
    {
        private static readonly ILog log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseDown()
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

                using (Business.BaseDown _Business = new Business.BaseDown())
                {
                    Dictionary<string, string> Process = _Business.ObtenerOrders(
                        "");

                    if (Process.Count > 0)
                    {
                        if (!Process.ContainsKey("0"))
                        {
                            string message = string.Empty;
                            Process.ToList().ForEach(delegate (KeyValuePair<string, string> item)
                            { message = message + item.Value; });

                            Procesado.Add("Error",
                              String.Format("Se ha generado un error en el proceso de generar Datos de Ordenes en la base de datos. el error se base en: {0}",
                              message));
                        }
                        else
                        {
                            Procesado.Add("OK","Se ha realizado el proceso de generar de Ordenes en la base de datos.");

                            log.Info("Se ha realizado el proceso de generar de Ordenes en la base de datos.");
                        }
                    }
                    else
                    {
                        Procesado.Add("OK","Se ha realizado el proceso de generar de Ordenes en la base de datos {0}.");

                        log.Info("Se ha realizado el proceso de generar de Ordenes en la base de datos.");
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
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~BaseDown()
        // {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
