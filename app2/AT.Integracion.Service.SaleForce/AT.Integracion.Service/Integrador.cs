using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace AT.Integracion.ServiceUP
{
    public partial class Integrador : ServiceBase
    {
        private System.Timers.Timer TimeUp = new System.Timers.Timer();
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
                Double.TryParse(Properties.Settings.Default.IntervalUp, out double IntervalUp);
                TimeUp.Interval = IntervalUp;

                TimeUp.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerUp);
            }
            catch (Exception ex)
            {
                log.Error(String.Format(ex.Message + ", del metodo: {0}",
                              System.Reflection.MethodBase.GetCurrentMethod().Name));

                EventLog.WriteEntry(sSource, ex.Message,
                    EventLogEntryType.Error, 234);
            }
        }

        private void OnTimerUp(object p, ElapsedEventArgs e)
        {
            log.Info(String.Format("Se inicia la ejecución del proceso de Generación de subida de los datos, en el  metodo: {0}",
                          System.Reflection.MethodBase.GetCurrentMethod().Name));
            TimeUp.Enabled = false;

            try
            {
                using (Base.BaseUp _Base = new Base.BaseUp())
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
                TimeUp.Enabled = true;
            }
        }

        protected override void OnStart(string[] args)
        {
            log.Info(String.Format("Se inicia la ejecución del metodo: {0}",
                            System.Reflection.MethodBase.GetCurrentMethod().Name));
            try
            {
                Double.TryParse(Properties.Settings.Default.IntervalUp, out double IntervalUp);

                TimeUp.Interval = IntervalUp;

                TimeUp.Start();
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
                TimeUp.Stop();
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