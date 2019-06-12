using AT.Common;
using AT.Connection.SAP;
using AT.Model.Data;
using AT.Model.View;
using IX.Model.View;
using log4net;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AT.Integracion.Data
{
    public class BaseDown:IDisposable
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseDown()
        {
            
        }

        public void DisConnect()
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                if (ConnectionSAP.CompanySAP.Connected)
                {
                    ConnectionSAP.DisConnect();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Connect(string FileName)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                if (FileName.Length > 0)
                {
                    ConnectionSAP.Connect(FileName);
                }
                else
                {
                    log.WarnFormat(String.Format("La ruta del archivo no esta bien definida, del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private BusinessPartner CrearBussinesPartner(BusinessPartner BusinessPartner_, string Prefijo)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.BusinessPartners Record = null;
            int ErrCode = 0;
            string ErrMsg = "";
            BusinessPartner Result = new BusinessPartner();
            try
            {
                Record = (SAPbobsCOM.BusinessPartners)ConnectionSAP.CompanySAP.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBusinessPartners);
                Record.CardName = BusinessPartner_.CardName;
                Record.CardType = BoCardTypes.cCustomer;
                Record.CardCode = string.Format("{0}{1}", Prefijo, BusinessPartner_.Identificacion);
                Record.Phone1 = BusinessPartner_.Phone1;
                Record.EmailAddress = BusinessPartner_.E_Mail;
                Record.FederalTaxID = BusinessPartner_.Identificacion;

                foreach (var item in BusinessPartner_.Direccion)
                {
                    switch (item.Tipo)
                    {
                        case "1":
                            Record.Addresses.AddressName = "DireccionFactura";
                            Record.Addresses.AddressType = BoAddressType.bo_ShipTo;
                            Record.Addresses.City = item.City;
                            Record.Addresses.Country = item.Country;
                            Record.Addresses.County = item.County;
                            Record.Addresses.Street = item.Address;
                            Record.Addresses.Add();
                            break;
                        default:
                            Record.Addresses.AddressName = "DireccionDespacho";
                            Record.Addresses.AddressType = BoAddressType.bo_ShipTo;
                            Record.Addresses.City = item.City;
                            Record.Addresses.Country = item.Country;
                            Record.Addresses.County = item.County;
                            Record.Addresses.Street = item.Address;
                            Record.Addresses.Add();
                            break;
                    }
                }

                
                
                try
                {
                    if (Record.ContactEmployees.Count == 0)
                    {
                        Record.ContactEmployees.E_Mail = BusinessPartner_.E_Mail;
                        Record.ContactEmployees.FirstName = BusinessPartner_.CardName;
                        Record.ContactEmployees.Phone1 = BusinessPartner_.Phone1;
                        Record.ContactEmployees.Name = BusinessPartner_.E_Mail;
                        Record.ContactEmployees.Position = "0";
                        Record.ContactEmployees.Add();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }


                Record.ContactPerson = BusinessPartner_.CardName;

                int resp = Record.Add();

                if (resp == 0)
                {
                    Result.CardCodeSAP = string.Format("{0}{1}", Prefijo, BusinessPartner_.Identificacion);
                    Result.CardName = BusinessPartner_.CardName;
                    Result.E_Mail = BusinessPartner_.E_Mail;
                    Result.Identificacion = BusinessPartner_.Identificacion;
                    Result.Phone1 = BusinessPartner_.Phone1;
                }
                else
                {
                    ConnectionSAP.CompanySAP.GetLastError(out ErrCode, out ErrMsg);
                    Result = null;
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
                Generic.FreeMemory<BusinessPartners>(ref Record);
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        private Dictionary<string, string> CreateOrder(Orders Order_, BusinessPartner BusinessPartner_)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Actualizar = new Dictionary<string, string>();

            SAPbobsCOM.Documents Record = null;
            int ErrCode = 0;
            string ErrMsg = "";

            try
            {
                Record = (SAPbobsCOM.Documents)ConnectionSAP.CompanySAP.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders);

                Record.CardCode =  BusinessPartner_.CardCodeSAP;
                Record.Comments = String.Format("{0}, Origen: Ecommerce, {1}", "Se ha generado una ordenes", Order_.DocEntry);
                Record.DocDueDate = DateTime.Today;

                Record.DocType = BoDocumentTypes.dDocument_Items;
                Record.DocumentSubType = BoDocumentSubType.bod_None;
                Record.NumAtCard = Order_.DocEntry.ToString();
                //log.Debug(DateTime.Now.ToString("dd/MM/yyyy"));
                foreach (OrdersDetalle RowDetail in Order_.Detail_)
                {
                    Record.Lines.ItemCode = RowDetail.ItemCode;
                    Record.Lines.Quantity = RowDetail.Quantity;
                    Record.Lines.TaxCode = "IVA";
                    //Record.Lines.Price = RowDetail.precio;
                    Record.Lines.UnitPrice = RowDetail.Price;
                    Record.Lines.Add();
                }

                int resp = Record.Add();

                log.Debug(string.Format("Ejecuto {0}", resp));

                if (resp == 0)
                {
                    if (Actualizar.Count > 0)
                    {
                        if (!Actualizar.ContainsKey(Order_.DocEntry.ToString()))
                            Actualizar.Add(Order_.DocEntry.ToString(),
                                "Error al intentar agregar un estatus  la orden de venta.");
                    }
                    else
                    {
                        Actualizar.Add(Order_.DocEntry.ToString(),
                                "Error al intentar agregar un estatus  la orden de venta.");
                    }

                    log.DebugFormat("DocInterno:{0}", Order_.DocEntry);
                }
                else
                {
                    ConnectionSAP.CompanySAP.GetLastError(out ErrCode, out ErrMsg);

                    log.Debug(string.Format("Error {0}", ErrMsg));

                    if (!Actualizar.ContainsKey(Order_.DocEntry.ToString()))
                        Actualizar.Add(Order_.DocEntry.ToString(), ErrMsg);
                }

                return Actualizar;
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
                Generic.FreeMemory<Documents>(ref Record);

                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public Dictionary<string, string> CreateOrders(List<Orders> Result, String Prefijo,  long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Actualizar = new Dictionary<string, string>();

            SAPbobsCOM.Documents Record = null;
            string ErrMsg = "";
            try
            {
                foreach (Orders Row in Result)
                {
                    bool ExistsBusinessPartner = false;
                    BusinessPartner BusinessPartner_ = new BusinessPartner();

                    try
                    {

                        if (BusinessPartner_.CardType != "1")
                        {
                            if (Row.CardCode.Length > 0)
                            {
                                log.Debug("RUT " + BusinessPartner_.Identificacion);
                                using (var Data = new BaseUp())
                                {
                                    BusinessPartner_ = Data.ObtenerBussinesPartnerSAP(BusinessPartner_, IdEmpresa);
                                }   
                            }

                            if (BusinessPartner_ != null)
                            {
                                if (BusinessPartner_.CardCodeSAP != null)
                                {
                                    log.Debug("CardCode " + BusinessPartner_.CardCodeSAP);
                                    ExistsBusinessPartner = true;
                                }
                            }
                            else
                            {
                                BusinessPartner_ = CrearBussinesPartner(BusinessPartner_, Prefijo);

                                if (BusinessPartner_ != null)
                                {
                                    if (BusinessPartner_.CardCodeSAP != null)
                                    {
                                        ExistsBusinessPartner = true;
                                    }
                                }
                                else
                                {
                                    ErrMsg = string.Format("No se pudo crear el cliente {0}", Row.CardCode);
                                    if (Actualizar.Count > 0)
                                    {
                                        if (!Actualizar.ContainsKey(Row.DocEntry.ToString()))
                                            Actualizar.Add(Row.DocEntry.ToString(), ErrMsg);
                                    }
                                    else
                                    {
                                        Actualizar.Add(Row.DocEntry.ToString(), ErrMsg);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ExistsBusinessPartner = true;
                        }

                        if (ExistsBusinessPartner)
                        {
                            if (Row != null)
                            {
                                if (BusinessPartner_ != null)
                                {
                                    Dictionary<string, string> result = CreateOrder(Row, BusinessPartner_);

                                    if (Actualizar.Count > 0)
                                    {
                                        foreach (KeyValuePair<string, string> item_ in result)
                                        {
                                            if (!Actualizar.ContainsKey(item_.Key))
                                                Actualizar.Add(item_.Key, item_.Value);
                                        }
                                    }
                                    else
                                    {
                                        foreach (KeyValuePair<string, string> item_ in result)
                                        {
                                            if (!Actualizar.ContainsKey(item_.Key))
                                                Actualizar.Add(item_.Key, item_.Value);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Actualizar.Count > 0)
                                    {
                                        if (!Actualizar.ContainsKey("-1"))
                                            Actualizar.Add("-1", string.Format("Este Cliente no se encuentra registrado {0}", Row.CardCode));
                                    }
                                    else
                                    {
                                        Actualizar.Add("-1", string.Format("Este Cliente no se encuentra registrado {0}", Row.CardCode));
                                    }
                                }
                            }
                            else
                            {
                                if (Actualizar.Count > 0)
                                {
                                    if (!Actualizar.ContainsKey("-1"))
                                        Actualizar.Add("-1", string.Format("Esta orden no esta completa {0}", Row.CardCode));
                                }
                                else
                                {
                                    Actualizar.Add("-1", string.Format("Esta orden no esta completa {0}", Row.CardCode));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrMsg = ex.Message;
                        if (Actualizar.Count > 0)
                        {
                            if (!Actualizar.ContainsKey(Row.DocEntry.ToString()))
                                Actualizar.Add(Row.DocEntry.ToString(), ErrMsg);
                        }
                        else
                        {
                            Actualizar.Add(Row.DocEntry.ToString(), ErrMsg);
                        }
                    }
                }

                return Actualizar;
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
                Generic.FreeMemory<Documents>(ref Record);

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
                    GC.SuppressFinalize(this);
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
