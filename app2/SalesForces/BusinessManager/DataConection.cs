using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessManager
{
    public class DataConection
    {
        readonly string cadena = "Data Source=ORLANDOGONZALE1\\SQLEXPRESS;Initial Catalog=SaleForceDB; Integrated Security=True";
        public SqlConnection connectDB = new SqlConnection();

        public DataConection()
        {
            connectDB.ConnectionString = cadena;
        }
    
        public void OpenConnection()
        {
            try
            {
                connectDB.Open();
                Console.WriteLine("Conexion Establecida");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Conexion Fallida, detalle:" + ex.Message);
            }
        }

        public void CloseConnection()
        {
            connectDB.Close();
        }
    }
}
