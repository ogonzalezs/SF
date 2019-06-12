using AT.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AT.Integracion.Base;
namespace AT.Integracion.ServiceDown
{
    public partial class Integrador : ServiceBase
    {
        private System.Timers.Timer TimeDown = new System.Timers.Timer();
        private string sSource;
        private string sLog;

        private static readonly ILog log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Integrador()
        {
            InitializeComponent();

            sSource = System.Windows.Forms.Application.ProductName;
            sLog = "Application";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
            try
            {
                Double.TryParse(Properties.Settings.Default.IntervalDown, out double IntervalDown);

                TimeDown.Interval = IntervalDown;

                TimeDown.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerDown);

            }
            catch (Exception ex)
            {
                log.Error(String.Format(ex.Message + ", del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

                EventLog.WriteEntry(sSource, ex.Message,
                    EventLogEntryType.Error, 234);
            }
        }

        private void OnTimerDown(object p, ElapsedEventArgs e)
        {
            log.Info(String.Format("Se inicia la ejecución del proceso de Generación de Orders en el  metodo: {0}",
                          System.Reflection.MethodBase.GetCurrentMethod().Name));

            TimeDown.Enabled = false;

            try
            {
                using (Base.BaseDown _Base = new Base.BaseDown())
                    {
                        string Message = "";
                        List<object> ListPrice = new List<object>();

                        Dictionary<string, string> ResultOrders = _Base.EjecutarServicioOrders();

                        if (ResultOrders.ContainsKey("OK"))
                        {
                            ResultOrders.TryGetValue("OK", out Message);

                            log.Info(Message);

                            EventLog.WriteEntry(sSource, Message,
                                EventLogEntryType.Information, 234);

                        }
                        else
                        {
                            if (ResultOrders.ContainsKey("Error"))
                            {
                                ResultOrders.TryGetValue("Error", out Message);

                                log.Error(Message);

                                EventLog.WriteEntry(sSource, Message,
                                    EventLogEntryType.Error, 234);
                            }
                            else
                            {
                                ResultOrders.TryGetValue("Warn", out Message);

                                log.Error(Message);

                                EventLog.WriteEntry(sSource, Message,
                                    EventLogEntryType.Warning, 234);

                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                string Message = String.Format(ex.Message + ", del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name);

                log.Error(Message);

                EventLog.WriteEntry(sSource, Message,
                    EventLogEntryType.Error, 234);

            }
            finally
            {
                TimeDown.Enabled = true;
            }
        }

        protected override void OnStart(string[] args)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                Double.TryParse(Properties.Settings.Default.IntervalDown, out double IntervalDown);


                TimeDown.Interval = IntervalDown;

                TimeDown.Start();
            }
            catch (Exception ex)
            {
                log.Error(String.Format(ex.Message + ", del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

                EventLog.WriteEntry(sSource, ex.Message,
                    EventLogEntryType.Error, 234);
            }
        }

        protected override void OnStop()
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));

            try
            {

                TimeDown.Stop();
            }
            catch (Exception ex)
            {
                log.Error(String.Format(ex.Message + ", del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

                EventLog.WriteEntry(sSource, ex.Message,
                    EventLogEntryType.Error, 234);
            }
        }
    }
}

