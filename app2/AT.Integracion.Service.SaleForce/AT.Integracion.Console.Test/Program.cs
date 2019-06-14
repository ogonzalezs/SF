using AT.Integracion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Integracion.Console.Test
{
    class Program
    {
        static BaseUp _BaseUp;
        static BaseDown _BaseDown;


        static void Setup()
        {
            _BaseUp = new BaseUp();
            _BaseDown = new BaseDown();
        }

        static void ServiceUp()
        {

            string Message = "";
            List<object> ListPrice = new List<object>();

            Dictionary<string, string> ResultOrders = _BaseUp.EjecutarServicioOrders();

            if (ResultOrders.ContainsKey("OK"))
            {
                ResultOrders.TryGetValue("OK", out Message);
            }
            else
            {
                if (ResultOrders.ContainsKey("Error"))
                {
                    ResultOrders.TryGetValue("Error", out Message);
                }
                else
                {
                    ResultOrders.TryGetValue("Warn", out Message);

                }
            }

        }

        static void ServiceDown()
        {

            string Message = "";
            List<object> ListPrice = new List<object>();

            Dictionary<string, string> ResultOrders = _BaseDown.EjecutarServicioOrders();

            if (ResultOrders.ContainsKey("OK"))
            {
                ResultOrders.TryGetValue("OK", out Message);
            }
            else
            {
                if (ResultOrders.ContainsKey("Error"))
                {
                    ResultOrders.TryGetValue("Error", out Message);
                }
                else
                {
                    ResultOrders.TryGetValue("Warn", out Message);

                }
            }
        }

        static void Main(string[] args)
        {
            Setup();
            ServiceUp();
            ServiceDown();
        }
    }
}
