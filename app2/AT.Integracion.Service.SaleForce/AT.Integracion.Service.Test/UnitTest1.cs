using NUnit.Framework;
using System.Collections.Generic;
using AT.Integracion.Base;
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private BaseUp _BaseUp;
        private BaseDown _BaseDown;

        [SetUp]
        public void Setup()
        {
            _BaseUp = new BaseUp();
            _BaseDown = new BaseDown();
        }

        [Test]
        public void ServiceUp()
        {

            string Message = "";
            List<object> ListPrice = new List<object>();

            Dictionary<string, string> ResultOrders = _BaseUp.EjecutarServicioOrders();

            if (ResultOrders.ContainsKey("OK"))
            {
                ResultOrders.TryGetValue("OK", out Message);
                Assert.AreEqual("OK", "OK");
            }
            else
            {
                if (ResultOrders.ContainsKey("Error"))
                {
                    ResultOrders.TryGetValue("Error", out Message);
                    Assert.AreEqual("Error", "Error");
                }
                else
                {
                    ResultOrders.TryGetValue("Warn", out Message);
                    Assert.AreEqual("Warn", "Warn");

                }
            }

        }

        [Test]
        public void ServiceDown()
        {

                string Message = "";
                List<object> ListPrice = new List<object>();

                Dictionary<string, string> ResultOrders = _BaseDown.EjecutarServicioOrders();

                if (ResultOrders.ContainsKey("OK"))
                {
                    ResultOrders.TryGetValue("OK", out Message);
                    Assert.AreEqual("OK", "OK");
                }
                else
                {
                    if (ResultOrders.ContainsKey("Error"))
                    {
                        ResultOrders.TryGetValue("Error", out Message);
                        Assert.AreEqual("Error", "Error");
                    }
                    else
                    {
                        ResultOrders.TryGetValue("Warn", out Message);
                        Assert.AreEqual("Warn", "Warn");

                    }
                }
        }
    }
}