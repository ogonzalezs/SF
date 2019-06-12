using AT.Model.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Integracion.Business
{
    public class BaseDown : IDisposable
    {
        private static readonly ILog log =
                    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseDown()
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="Url">             </param>
        /// <param name="token">           </param>
        /// <param name="CorreoOrigen">    </param>
        /// <param name="CorreoDestino">   </param>
        /// <param name="PassCorreoOrigen"></param>
        /// <param name="Prefijo">         </param>
        /// <param name="ServicioSMTP">    </param>
        /// <param name="CardCodeBoleta">  </param>
        /// <returns></returns>
        public Dictionary<string, string> ObtenerOrders(string Prefijo)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia proceso de Consulta a base de datos, con el metodo: {0}",
                          System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Procesado = new Dictionary<string, string>();

            try
            {
                List<Enlace> Enlace = new List<Enlace>();

                try
                {
                    using (var Data = new Data.BaseSQLUp())
                    {
                        var ResultTmp = Data.ObtenerEntidades();

                        if (ResultTmp.Count > 0)
                        {
                            var Index = 0;
                            foreach (var item in ResultTmp)
                            {
                                Enlace.Add(new Enlace() { Id = Index + 1, Table = "OCRD", Fecha = Data.ObtenerBussinesPartner(), FileName = item.Value, IdEmpresas = item.Key });
                                Enlace.Add(new Enlace() { Id = Index + 2, Table = "OITM", Fecha = Data.ObtenerItem(), FileName = item.Value, IdEmpresas = item.Key });
                                Enlace.Add(new Enlace() { Id = Index + 3, Table = "OSLP", Fecha = Data.ObtenerSaleSMan(), FileName = item.Value, IdEmpresas = item.Key });
                                Enlace.Add(new Enlace() { Id = Index + 4, Table = "ITM1", Fecha = Data.ObtenerPriceList(), FileName = item.Value, IdEmpresas = item.Key });
                                Index = Index + 4;
                            }
                            Procesado.Add("0", "Se inicia proceso de subida de datos.");
                        }
                        else
                        {
                            Procesado.Add("-1", "No se ha obtenido los registros asociados a la conexión");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Procesado.Add("-1", string.Format("{0}, del metodo: {1}", ex.Message,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name));
                }

                if (Enlace != null)
                {
                    if (Enlace.Count > 0)
                    {
                        var OrdersTemp_ = new List<Orders>();

                        using (var Data = new Data.BaseSQLUp())
                        {
                            OrdersTemp_ = Data.ObtenerOrdenes();
                        }

                        using (var Data = new Data.BaseDown())
                        {
                            foreach (var item in Enlace)
                            {
                                Data.Connect(item.FileName);

                                List<Orders> _Orders_ = new List<Orders>();
                                if (_Orders_.Count > 0)
                                {
                                    Procesado = Data.CreateOrders(_Orders_, Prefijo, item.IdEmpresas);

                                    if (Procesado.Count > 0)
                                    {
                                        if (!Procesado.ContainsKey("0"))
                                        {
                                            string msg = string.Empty;
                                            foreach (KeyValuePair<string, string> itemResult in Procesado)
                                            {
                                                msg = string.Format("{0}, {1}", msg, itemResult.Value);
                                            }
                                            log.ErrorFormat("Se ha generado un error controlado en el servicio. {0}", msg);
                                        }
                                    }
                                }
                                else
                                {
                                    log.InfoFormat("No existe Ordenes por procesar, del metodo: {0}",
                                      System.Reflection.MethodBase.GetCurrentMethod().Name);

                                    Procesado.Add("0", "No existe Ordenes por procesar, del metodo");
                                }
                            }
                        }
                    }
                }
                //if (OrdersTemp_ != null)
                //{
                //    if (OrdersTemp_.Count > 0)
                //    {
                //        log.DebugFormat("Inicial validación de empresa {0} ", Empresa);

                //        foreach (var item in OrdersTemp_)
                //        {
                //            if (item.listado_articulos.Where(w => w.empresa.ToUpper().Trim().Equals(Empresa)).Count() > 0)
                //            {
                //                Orders_.Add(new Orders
                //                {
                //                    cliente = item.cliente,
                //                    direccionDespacho = item.direccionDespacho,
                //                    direccionFactura = item.direccionFactura,
                //                    general = item.general,
                //                    listado_articulos = item.listado_articulos.Where(w =>
                //                    w.empresa.ToUpper().Trim().Equals(Empresa)).ToList()
                //                });
                //            }
                //        }

                //        using (Data.BaseDown data = new Data.BaseDown(FileName))
                //        {
                            
                //        }
                //    }
                //}
                //else
                //{
                //    log.InfoFormat("No existe Ordenes por procesar, del metodo: {0}",
                //            System.Reflection.MethodBase.GetCurrentMethod().Name);

                //    Procesado.Add("0", "No existe Ordenes por procesar, del metodo");
                //}

                return Procesado;
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
