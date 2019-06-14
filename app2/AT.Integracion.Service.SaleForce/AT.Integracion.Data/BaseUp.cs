using AT.Common;
using AT.Connection.SAP;
using AT.Model.Data;
using AT.Model.View;
using log4net;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AT.Integracion.Data
{
    public class BaseUp : IDisposable
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseUp()
        {
        }

        public void DisConnect()
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                if (ConnectionSAP.CompanySAP!= null)
                { 
                    if (ConnectionSAP.CompanySAP.Connected)
                    {
                        ConnectionSAP.DisConnect();
                    }
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

        public List<OCRD> ObtenerBussinesPartner(DateTime UpdateDate)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.Recordset Record = null;

            List<OCRD> Result = new List<OCRD>();

            try
            {
                string SQL = string.Format(Generic.LoadFile("OCRD.dat", "Querys"),
                        UpdateDate.ToString("yyyyMMdd"));

                if (log.IsDebugEnabled) log.Debug(SQL);

                Record = (Recordset)ConnectionSAP.CompanySAP.GetBusinessObject(BoObjectTypes.BoRecordset);

                Record.DoQuery(SQL);

                if (Record.RecordCount > 0)
                {
                    Result = ManagerDataGeneric.GetDataQuery<OCRD>(Record);
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
                Generic.FreeMemory<Recordset>(ref Record);
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public BusinessPartner ObtenerBussinesPartnerSAP(BusinessPartner BusinessPartner_, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.Recordset Record = null;

            BusinessPartner Result = new BusinessPartner();

            try
            {
                string SQL = string.Format(Generic.LoadFile("OCRD_CardCode.dat", "Querys"),
                        BusinessPartner_.CardCodeSAP);

                if (log.IsDebugEnabled) log.Debug(SQL);

                Record = (Recordset)ConnectionSAP.CompanySAP.GetBusinessObject(BoObjectTypes.BoRecordset);

                Record.DoQuery(SQL);

                if (Record.RecordCount > 0)
                {
                    var Result_ = ManagerDataGeneric.GetDataQuery<OCRD>(Record);
                    if (Result_.Count > 0)
                    {
                        foreach (var item in Result_)
                        {
                            Result = new BusinessPartner()
                            {
                                CardCode = item.CardCode,
                                Address = item.Address,
                                Balance = item.Balance,
                                CardCodeSAP = item.CardCode,
                                CardName = item.CardName,
                                City = item.City,
                                CntctPrsn = item.CntctPrsn,
                                Country = item.Country,
                                County = item.County,
                                E_Mail = item.E_Mail,
                                Identificacion = item.LicTradNum,
                                ListNum = item.ListNum,
                                Phone1 = item.Phone1,
                                Phone2 = item.Phone2,
                                State = item.State,
                                CardType = "",
                                ValidFor = item.ValidFor,
                                IdEmpresa = IdEmpresa
                            };
                        }
                    }
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
                Generic.FreeMemory<Recordset>(ref Record);
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public List<ITM1> ObtenerPriceList(DateTime UpdateDate)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.Recordset Record = null;

            List<ITM1> Result = new List<ITM1>();

            try
            {
                string SQL = Generic.LoadFile("ITM1.dat", "Querys");

                if (log.IsDebugEnabled) log.Debug(SQL);

                Record = (Recordset)ConnectionSAP.CompanySAP.GetBusinessObject(BoObjectTypes.BoRecordset);

                Record.DoQuery(SQL);

                if (Record.RecordCount > 0)
                {
                    Result = ManagerDataGeneric.GetDataQuery<ITM1>(Record);
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
                Generic.FreeMemory<Recordset>(ref Record);
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public List<OITM> ObtenerItem(DateTime UpdateDate)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.Recordset Record = null;

            List<OITM> Result = new List<OITM>();

            try
            {
                string SQL = string.Format(Generic.LoadFile("OITM.dat", "Querys"),
                        UpdateDate.ToString("yyyyMMdd"));

                if (log.IsDebugEnabled) log.Debug(SQL);

                Record = (Recordset)ConnectionSAP.CompanySAP.GetBusinessObject(BoObjectTypes.BoRecordset);

                Record.DoQuery(SQL);

                if (Record.RecordCount > 0)
                {
                    Result = ManagerDataGeneric.GetDataQuery<OITM>(Record);
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
                Generic.FreeMemory<Recordset>(ref Record);
                watch.Stop();

                if (log.IsDebugEnabled) log.DebugFormat("{0} Se ejecuto en {1} ms",
                    System.Reflection.MethodBase.GetCurrentMethod().Name, watch.ElapsedMilliseconds);
            }
        }

        public List<OSLP> ObtenerSaleSMan(DateTime UpdateDate)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            SAPbobsCOM.Recordset Record = null;

            List<OSLP> Result = new List<OSLP>();

            try
            {
                string SQL = Generic.LoadFile("OSLP.dat", "Querys");

                if (log.IsDebugEnabled) log.Debug(SQL);

                Record = (Recordset)ConnectionSAP.CompanySAP.GetBusinessObject(BoObjectTypes.BoRecordset);

                Record.DoQuery(SQL);

                if (Record.RecordCount > 0)
                {
                    Result = ManagerDataGeneric.GetDataQuery<OSLP>(Record);
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
                Generic.FreeMemory<Recordset>(ref Record);
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
                    DisConnect();
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

        #endregion IDisposable Support
    }
}