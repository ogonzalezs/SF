using log4net;
using System;
using System.Collections.Generic;
using AT.Model.Data;

namespace AT.Integracion.Business
{
    public class BaseUp:IDisposable
    {
        private static readonly ILog log =
                    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseUp()
        {

        }

        public Dictionary<string, string> ObtenerData()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.InfoFormat("Se inicia proceso de Consulta a base de datos, con el metodo: {0}",
                          System.Reflection.MethodBase.GetCurrentMethod().Name);

            Dictionary<string, string> Procesado = new Dictionary<string, string>();

            try
            {
                List<Enlace> Enlace = new List<Enlace>();

                try
                {
                    using (var Data = new Data.BaseSQLUp())
                    {
                        var ResultTmp = Data.ObtenerEntidades();

                        if(ResultTmp.Count>0)
                        {
                            var Index = 0;
                            foreach (var item in ResultTmp)
                            {
                                Enlace.Add(new Enlace() { Id = Index + 1, Table = "OCRD", Fecha = Data.ObtenerBussinesPartner(), FileName = item.Value, IdEmpresas= item.Key });
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
                        using (var Data = new Data.BaseUp())
                        {
                            var DB = string.Empty;
                            foreach (var item in Enlace)
                            {
                                if(DB!= item.FileName)
                                {
                                    Data.DisConnect();
                                    Data.Connect(item.FileName);
                                    DB = item.FileName;
                                }
                                

                                switch (item.Table)
                                {
                                    case "OCRD":
                                        var ResultBusinessPartner = Data.ObtenerBussinesPartner(item.Fecha);

                                        if (ResultBusinessPartner.Count > 0)
                                        {
                                            using (var DataSQL = new Data.BaseSQLUp())
                                            {
                                                var Process = DataSQL.RegistrarBussinesPartner(ResultBusinessPartner, item.IdEmpresas);
                                                if (Process.ContainsKey("-1"))
                                                    Procesado.Add("0", "Se ha procesado los socios de negocios");
                                            }
                                        }
                                        else
                                        {
                                            if(Procesado.ContainsKey("-1"))
                                                Procesado.Add("-1", "No se ha podido subir a la base de datos los registros de Socio de negocios");
                                        }
                                        break;
                                    case "OITM":
                                        var ResultItem = Data.ObtenerItem(item.Fecha);

                                        if (ResultItem.Count > 0)
                                        {
                                            using (var DataSQL = new Data.BaseSQLUp())
                                            {
                                                var Process = DataSQL.RegistrarItem(ResultItem, item.IdEmpresas);
                                                if (Process.ContainsKey("-1"))
                                                    Procesado.Add("0", "Se ha procesado los articulos");
                                            }
                                        }
                                        else
                                        {
                                            if (Procesado.ContainsKey("-1"))
                                                Procesado.Add("-1", "No se ha podido subir a la base de datos los registros de articulos");
                                        }
                                        break;
                                    case "OSLP":
                                        var ResultSalesMan = Data.ObtenerSaleSMan(item.Fecha);

                                        if (ResultSalesMan.Count > 0)
                                        {
                                            using (var DataSQL = new Data.BaseSQLUp())
                                            {
                                                var Process = DataSQL.RegistrarSalesMan(ResultSalesMan, item.IdEmpresas);
                                                if (Process.ContainsKey("-1"))
                                                    Procesado.Add("0", "Se ha procesado los vendedores");
                                            }
                                        }
                                        else
                                        {
                                            if (Procesado.ContainsKey("-1"))
                                                Procesado.Add("-1", "No se ha podido subir a la base de datos los registros de vendedores");
                                        }
                                        break;
                                    case "ITM1":
                                        var ResulPriceList = Data.ObtenerPriceList(item.Fecha);

                                        if (ResulPriceList.Count > 0)
                                        {
                                            using (var DataSQL = new Data.BaseSQLUp())
                                            {
                                                var Process = DataSQL.RegistrarPriceList(ResulPriceList, item.IdEmpresas);
                                                if (Process.ContainsKey("-1"))
                                                    Procesado.Add("0", "Se ha procesado las listas de precios");
                                            }
                                             
                                        }
                                        else
                                        {
                                            if (Procesado.ContainsKey("-1"))
                                                Procesado.Add("-1", "No se ha podido subir a la base de datos los registros de  listas de precios");
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    log.InfoFormat("No existe Ordenes por procesar, del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name);

                    Procesado.Add("0", "No existe Ordenes por procesar, del metodo");
                }

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
