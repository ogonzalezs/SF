namespace AT.Middleware.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using AT.Middleware.Service.Interface;
    using log4net;
    using System.Runtime.Serialization.Json;
    using System.IO;
    using AT.Model.View;
    using System.ServiceModel.Activation;

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase
    //       "Item" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Iteme de prueba WCF para probar este servicio, seleccione Item.svc o
    //       Item.svc.cs en el Explorador de soluciones e inicie la depuración.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Item : IItem, IDisposable
    {
        private static readonly ILog log =
                LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Business.Item oItem = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Arovario, 26-09-2017. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Item()
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                oItem = Authorization.ItemAuthorization.oItem;
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
        /// <summary>   Gets a Item. </summary>
        ///
        /// <remarks>   Arovario, 23-09-2017. </remarks>
        ///
        /// <param name="CardCode"> The card code. </param>
        ///
        /// <returns>   The Item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetItem(string ItemCode)
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Items>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oItem.GetOITM(ItemCode);

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
        /// <summary>   Gets Item all. </summary>
        ///
        /// <remarks>   Arovario, 23-09-2017. </remarks>
        ///
        /// <returns>   The Item all. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetItemAll()
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Items>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oItem.GetOITM();

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
        /// <summary>   Gets item by price list. </summary>
        ///
        /// <remarks>   Arovario, 26-09-2017. </remarks>
        ///
        /// <param name="ItemCode">     The item code. </param>
        /// <param name="PriceList">    List of prices. </param>
        ///
        /// <returns>   The item by price list. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetItemByPriceList(string ItemCode, string PriceList)
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Items>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oItem.GetOITMByPriceList(ItemCode, PriceList);

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
        /// <summary>   Gets item by ware house. </summary>
        ///
        /// <remarks>   Arovario, 26-09-2017. </remarks>
        ///
        /// <param name="ItemCode"> The item code. </param>
        /// <param name="WhsCode">  The whs code. </param>
        ///
        /// <returns>   The item by ware house. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetItemByWareHouse(string ItemCode, string WhsCode)
        {
            log.Info(String.Format("Se incia la ejecución del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

            var Resp = "";

            try
            {
                var data = new DataContractJsonSerializer(typeof(List<Items>));

                using (var StrMem = new MemoryStream())
                {
                    var Result = oItem.GetOITMByWareHouse(ItemCode, WhsCode);

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