using AT.Model.Data;
using AT.Model.View;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AT.Integracion.Data
{
    public class BaseSQLUp : IDisposable
    {
        private static readonly ILog log =
                    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseSQLUp()
        { }

        #region "Consultar"

        public Dictionary<long, string> ObtenerEntidades()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<long, string> Result = new Dictionary<long, string>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        var Result_ = context.t_Connection.Select(s => new { s.FileName, s.IdConnection }).ToList();

                        if (Result_.Count > 0)
                        {
                            foreach (var item in Result_)
                            {
                                Result.Add(item.IdConnection, item.FileName);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public DateTime ObtenerBussinesPartner()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            DateTime Result = new DateTime();

            try
            {
                Result = DateTime.Now.AddYears(-2);

                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        List<DateTime?> Result_ = context.t_Customer.Select(s => s.DateUp).ToList();

                        if (Result_.Count > 0)
                        {
                            Result = Result_.Max().Value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public DateTime ObtenerPriceList()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            DateTime Result = new DateTime();

            try
            {
                Result = DateTime.Now.AddYears(-2);

                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        List<DateTime?> Result_ = context.t_ItemPrice.Select(s => s.DateUp).ToList();

                        if (Result_.Count > 0)
                        {
                            Result = Result_.Max().Value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public DateTime ObtenerItem()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            DateTime Result = new DateTime();

            try
            {
                Result = DateTime.Now.AddYears(-2);

                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        List<DateTime?> Result_ = context.t_Item.Select(s => s.DateUp).ToList();

                        if (Result_.Count > 0)
                        {
                            Result = Result_.Max().Value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public DateTime ObtenerSaleSMan()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            DateTime Result = new DateTime();

            try
            {
                Result = DateTime.Now.AddYears(-2);

                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        List<DateTime?> Result_ = context.t_Seller.Select(s => s.DateUp).ToList();

                        if (Result_.Count > 0)
                        {
                            Result = Result_.Max().Value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public DateTime ObtenerOrden()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            DateTime Result = new DateTime();

            try
            {
                Result = DateTime.Now.AddDays(-2);

                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        List<DateTime?> Result_ = context.t_Orders.Select(s => s.DateUp).ToList();

                        if (Result_.Count > 0)
                        {
                            Result = Result_.Max().Value;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return Result;
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

        public BusinessPartner ObtenerBussinesPartner(string CardCode, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            BusinessPartner Result = new BusinessPartner();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        var Result_ = context.t_Customer.Where(w=>w.CardCode.Equals(CardCode)).FirstOrDefault();
                        if(Result_ != null)
                        {
                            Result = new BusinessPartner()
                            {
                                CardCode = Result_.CardCode,
                                Address = Result_.Address,
                                Balance = (Result_.Balance.HasValue ? Convert.ToDouble(Result_.Balance.Value) : 0),
                                CardCodeSAP = Result_.CardCode,
                                CardName = Result_.CardName,
                                City = Result_.City,
                                CntctPrsn = Result_.CntctPrsn,
                                Country = Result_.Country,
                                County = Result_.County,
                                E_Mail = Result_.E_Mail,
                                Identificacion = Result_.Identificacion,
                                ListNum = int.Parse(Result_.ListNum),
                                Phone1 = Result_.Phone1,
                                Phone2 = Result_.Phone2,
                                State = Result_.State,
                                CardType = "",
                                ValidFor = "",
                                IdEmpresa = IdEmpresa
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                return Result;
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

        public List<Orders> ObtenerOrdenes(DateTime DateDown, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            List<Orders> Result = new List<Orders>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
  
                        Result = context.t_Orders.Join(context.t_Customer,
                            ordenes => ordenes.CardCode,
                            cliente => cliente.CardCode,
                            (ordenes, cliente) => new Orders
                            {
                                DocEntry = ordenes.DocEntry,
                                CardCode = cliente.CardCode,
                                Comments = ordenes.Comments,
                                DiscSum = ordenes.DiscSum,
                                DocDate = ordenes.DocDate,
                                DocNum = ordenes.DocNum,
                                DocTotal = ordenes.DocTotal,
                                VatSum = ordenes.VatSum,
                                DateDown = ordenes.DateDown.Value,
                                 IdCompany = ordenes.IdCompany,
                                Detail_ = ordenes.t_OrdersDetail.Select(s => new OrdersDetalle()
                                {
                                    DocEntry = s.DocEntry,
                                    Dscription = s.Dscription,
                                    ItemCode = s.ItemCode,
                                    DiscPrcnt = s.DiscPrcnt,
                                    LineTotal = s.LineTotal,
                                    Price = s.Price,
                                    Quantity = s.Quantity,
                                    TaxCode = s.TaxCode,
                                    VatSum = s.VatSum,
                                    WhsCode = s.WhsCode,
                                    ShipDate = s.ShipDate
                                }).ToList()
                            }).Where(w=> w.DocDate>= DateDown && 
                            w.IdCompany.Equals(IdEmpresa) && w.DocNum.Equals(0)).ToList();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return Result;
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

        #endregion "Consultar"

        #region "Registrar-Actualizar"

        public Dictionary<string, string> RegistrarBussinesPartner(List<OCRD> Data, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Result = new Dictionary<string, string>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        foreach (OCRD item in Data)
                        {
                            var Data_ = context.t_Customer.Where(w => w.IdCompany.Equals(IdEmpresa) &&
                            w.CardCode.Equals(item.CardCode) &&
                            w.DateUp.Value != DateTime.Now).FirstOrDefault();
                            if (Data_ != null)
                            {
                                Data_.Address = item.Address;
                                Data_.Balance = Convert.ToDecimal(item.Balance);
                                Data_.CardName = item.CardName;
                                Data_.City = item.City;
                                Data_.CntctPrsn = item.CntctPrsn;
                                Data_.Country = item.Country;
                                Data_.County = item.County;
                                Data_.CreditLine = Convert.ToDecimal(item.CreditLine);
                                Data_.E_Mail = item.E_Mail;
                                Data_.DateUp = DateTime.Now;
                                Data_.sysUpdateDate = DateTime.Now;
                                Data_.Identificacion = item.LicTradNum;
                                Data_.Phone1 = item.Phone1;
                                Data_.Phone2 = item.Phone2;
                                Data_.ZipCode = item.ZipCode;
                                context.t_Customer.Attach(Data_);
                                context.Entry(Data_).State = EntityState.Modified;
                            }
                            else
                            {
                                context.t_Customer.Add(new t_Customer()
                                {
                                    Address = item.Address,
                                    Balance = Convert.ToDecimal(item.Balance),
                                    CardName = item.CardName,
                                    City = item.City,
                                    CntctPrsn = item.CntctPrsn,
                                    Country = item.Country,
                                    County = item.County,
                                    CreditLine = Convert.ToDecimal(item.CreditLine),
                                    E_Mail = item.E_Mail,
                                    DateUp = DateTime.Now,
                                    IdCompany = IdEmpresa,
                                    Identificacion = item.LicTradNum,
                                    Phone1 = item.Phone1,
                                    Phone2 = item.Phone2,
                                    ZipCode = item.ZipCode,
                                    sysCreateDate = DateTime.Now,
                                    CardCode = item.CardCode,
                                    CardCodeSAP = item.CardCode
                                });
                            }
                        }
                        int Process = context.SaveChanges();

                        if (Process != 0)
                        {
                            if (!Result.ContainsKey("0"))
                                Result.Add("0", "Procesado");
                        }
                    }
                    catch (Exception ex)
                    {
                        Result.Add("-1", string.Format("ERROR: {0}", ex.Message));
                    }
                }
                return Result;
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

        public Dictionary<string, string> RegistrarPriceList(List<ITM1> Data, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Result = new Dictionary<string, string>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        foreach (ITM1 item in Data)
                        {
                            try
                            {
                                var Data_ = context.t_ItemPrice.Where(w => w.IdCompany.Equals(IdEmpresa) &&
                            w.PriceList.Equals(item.PriceList) &&
                            w.ItemCode.Equals(item.ItemCode) &&
                            w.DateUp.Value != DateTime.Now).FirstOrDefault();
                                if (Data_ != null)
                                {
                                    Data_.Price = Convert.ToDecimal(item.Price);
                                    Data_.DateUp = DateTime.Now;

                                    context.t_ItemPrice.Attach(Data_);
                                    context.Entry(Data_).State = EntityState.Modified;
                                }
                                else
                                {
                                    context.t_ItemPrice.Add(new t_ItemPrice()
                                    {
                                        ItemCode = item.ItemCode,
                                        Price = Convert.ToDecimal(item.Price),
                                        PriceList = item.PriceList,
                                        DateUp = DateTime.Now,
                                        IdCompany = IdEmpresa
                                    });
                                }

                                int Process = context.SaveChanges();

                                if (Process != 0)
                                {
                                    if (!Result.ContainsKey("0"))
                                        Result.Add("0", "Procesado");
                                }
                            }
                            catch (Exception ex)
                            {
                                if (!Result.ContainsKey("-1" + item))
                                    Result.Add("-1" + item, string.Format("ERROR: {0}", ex.Message));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!Result.ContainsKey("-1"))
                            Result.Add("-1", string.Format("ERROR: {0}", ex.Message));
                    }
                }
                return Result;
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

        public Dictionary<string, string> RegistrarItem(List<OITM> Data, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Result = new Dictionary<string, string>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        foreach (OITM item in Data)
                        {
                            var Data_ = context.t_Item.Where(w => w.IdCompany.Equals(IdEmpresa) &&
                            w.ItemCode.Equals(item.ItemCode) &&
                            w.DateUp.Value != DateTime.Now).FirstOrDefault();
                            if (Data_ != null)
                            {
                                Data_.ItemCode = item.ItemCode;
                                Data_.ItemName = item.ItemName;
                                Data_.OnHand = Convert.ToDecimal(item.OnHand);
                                Data_.IsCommited = Convert.ToDecimal(item.IsCommited);
                                Data_.OnOrder = Convert.ToDecimal(item.OnOrder);
                                Data_.CardCode = item.CardCode;
                                Data_.SuppCatNum = item.SuppCatNum;
                                Data_.BuyUnitMsr = item.BuyUnitMsr;
                                Data_.NumInBuy = Convert.ToDecimal(item.NumInBuy);
                                Data_.SalUnitMsr = item.SalUnitMsr;
                                Data_.NumInSale = Convert.ToDecimal(item.NumInSale);
                                Data_.SHeight1 = Convert.ToDecimal(item.SHeight1);
                                Data_.SHght1Unit = item.SHght1Unit;
                                Data_.SHeight2 = Convert.ToDecimal(item.SHeight2);
                                Data_.SHght2Unit = item.SHght2Unit;
                                Data_.SWidth1 = Convert.ToDecimal(item.SWidth1);
                                Data_.SWdth1Unit = item.SWdth1Unit;
                                Data_.SWidth2 = Convert.ToDecimal(item.SWidth2);
                                Data_.SWdth2Unit = item.SWdth2Unit;
                                Data_.SLength1 = Convert.ToDecimal(item.SLength1);
                                Data_.SLen1Unit = item.SLen1Unit;
                                Data_.Slength2 = Convert.ToDecimal(item.Slength2);
                                Data_.SLen2Unit = item.SLen2Unit;
                                Data_.SVolume = Convert.ToDecimal(item.SVolume);
                                Data_.SVolUnit = item.SVolUnit;
                                Data_.SWeight1 = Convert.ToDecimal(item.SWeight1);
                                Data_.SWght1Unit = item.SWght1Unit;
                                Data_.SWeight2 = Convert.ToDecimal(item.SWeight2);
                                Data_.SWght2Unit = item.SWght2Unit;
                                Data_.BHeight1 = Convert.ToDecimal(item.BHeight1);
                                Data_.BHght1Unit = item.BHght1Unit;
                                Data_.BHeight2 = Convert.ToDecimal(item.BHeight2);
                                Data_.BHght2Unit = item.BHght2Unit;
                                Data_.BWidth1 = Convert.ToDecimal(item.BWidth1);
                                Data_.BWdth1Unit = item.BWdth1Unit;
                                Data_.BWidth2 = Convert.ToDecimal(item.BWidth2);
                                Data_.BWdth2Unit = item.BWdth2Unit;
                                Data_.BLength1 = Convert.ToDecimal(item.BLength1);
                                Data_.BLen1Unit = item.BLen1Unit;
                                Data_.Blength2 = Convert.ToDecimal(item.Blength2);
                                Data_.BLen2Unit = item.BLen2Unit;
                                Data_.BVolume = Convert.ToDecimal(item.BVolume);
                                Data_.BVolUnit = item.BVolUnit;
                                Data_.BWeight1 = Convert.ToDecimal(item.BWeight1);
                                Data_.BWght1Unit = item.BWght1Unit;
                                Data_.BWeight2 = Convert.ToDecimal(item.BWeight2);
                                Data_.BWght2Unit = item.BWght2Unit;
                                Data_.FirmCode = item.FirmCode;
                                Data_.DateUp = DateTime.Now;
                                Data_.sysUpdateDate = DateTime.Now;
                                //,validFor = item.validFor,
                                //frozenFor = item.frozenFor

                                context.t_Item.Attach(Data_);
                                context.Entry(Data_).State = EntityState.Modified;
                            }
                            else
                            {
                                context.t_Item.Add(new t_Item()
                                {
                                    ItemCode = item.ItemCode,
                                    ItemName = item.ItemName,
                                    OnHand = Convert.ToDecimal(item.OnHand),
                                    IsCommited = Convert.ToDecimal(item.IsCommited),
                                    OnOrder = Convert.ToDecimal(item.OnOrder),
                                    CardCode = item.CardCode,
                                    SuppCatNum = item.SuppCatNum,
                                    BuyUnitMsr = item.BuyUnitMsr,
                                    NumInBuy = Convert.ToDecimal(item.NumInBuy),
                                    SalUnitMsr = item.SalUnitMsr,
                                    NumInSale = Convert.ToDecimal(item.NumInSale),
                                    SHeight1 = Convert.ToDecimal(item.SHeight1),
                                    SHght1Unit = item.SHght1Unit,
                                    SHeight2 = Convert.ToDecimal(item.SHeight2),
                                    SHght2Unit = item.SHght2Unit,
                                    SWidth1 = Convert.ToDecimal(item.SWidth1),
                                    SWdth1Unit = item.SWdth1Unit,
                                    SWidth2 = Convert.ToDecimal(item.SWidth2),
                                    SWdth2Unit = item.SWdth2Unit,
                                    SLength1 = Convert.ToDecimal(item.SLength1),
                                    SLen1Unit = item.SLen1Unit,
                                    Slength2 = Convert.ToDecimal(item.Slength2),
                                    SLen2Unit = item.SLen2Unit,
                                    SVolume = Convert.ToDecimal(item.SVolume),
                                    SVolUnit = item.SVolUnit,
                                    SWeight1 = Convert.ToDecimal(item.SWeight1),
                                    SWght1Unit = item.SWght1Unit,
                                    SWeight2 = Convert.ToDecimal(item.SWeight2),
                                    SWght2Unit = item.SWght2Unit,
                                    BHeight1 = Convert.ToDecimal(item.BHeight1),
                                    BHght1Unit = item.BHght1Unit,
                                    BHeight2 = Convert.ToDecimal(item.BHeight2),
                                    BHght2Unit = item.BHght2Unit,
                                    BWidth1 = Convert.ToDecimal(item.BWidth1),
                                    BWdth1Unit = item.BWdth1Unit,
                                    BWidth2 = Convert.ToDecimal(item.BWidth2),
                                    BWdth2Unit = item.BWdth2Unit,
                                    BLength1 = Convert.ToDecimal(item.BLength1),
                                    BLen1Unit = item.BLen1Unit,
                                    Blength2 = Convert.ToDecimal(item.Blength2),
                                    BLen2Unit = item.BLen2Unit,
                                    BVolume = Convert.ToDecimal(item.BVolume),
                                    BVolUnit = item.BVolUnit,
                                    BWeight1 = Convert.ToDecimal(item.BWeight1),
                                    BWght1Unit = item.BWght1Unit,
                                    BWeight2 = Convert.ToDecimal(item.BWeight2),
                                    BWght2Unit = item.BWght2Unit,
                                    FirmCode = item.FirmCode,
                                    DateUp = DateTime.Now,
                                    sysCreateDate = DateTime.Now,
                                    IdCompany = IdEmpresa
                                    //,validFor = item.validFor,
                                    //frozenFor = item.frozenFor
                                });
                            }
                        }

                        int Process = context.SaveChanges();

                        if (Process != 0)
                        {
                            if (!Result.ContainsKey("0"))
                                Result.Add("0", "Procesado");
                        }
                    }
                    catch (Exception ex)
                    {
                        Result.Add("-1", string.Format("ERROR: {0}", ex.Message));
                    }
                }
                return Result;
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

        public Dictionary<string, string> RegistrarSalesMan(List<OSLP> Data, long IdEmpresa)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            Dictionary<string, string> Result = new Dictionary<string, string>();

            try
            {
                using (SALESFORCESEntities context = new SALESFORCESEntities())
                {
                    try
                    {
                        foreach (OSLP item in Data)
                        {
                            var Data_ = context.t_Seller.Where(w => w.IdCompany.Equals(IdEmpresa) &&
                            w.SlpCode.Equals(item.SlpCode) &&
                            w.DateUp.Value != DateTime.Now).FirstOrDefault();

                            if (Data_ != null)
                            {
                                Data_.SlpName = item.SlpName;
                                Data_.Email = item.Email;
                                Data_.DateUp = DateTime.Now;

                                context.t_Seller.Attach(Data_);
                                context.Entry(Data_).State = EntityState.Modified;
                            }
                            else
                            {
                                context.t_Seller.Add(new t_Seller()
                                {
                                    SlpCode = item.SlpCode,
                                    SlpName = item.SlpName,
                                    Email = item.Email,
                                    DateUp = DateTime.Now,
                                    IdCompany = IdEmpresa
                                });
                            }
                        }

                        int Process = context.SaveChanges();

                        if (Process != 0)
                        {
                            if (!Result.ContainsKey("0"))
                                Result.Add("0", "Procesado");
                        }
                    }
                    catch (Exception ex)
                    {
                        Result.Add("-1", string.Format("ERROR: {0}", ex.Message));
                    }
                }
                return Result;
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

        #endregion "Registrar-Actualizar"

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
        // ~BaseSQLUp() {
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