using Interface.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Security
{
    public partial class Login : Form
    {
        private BusinessManager.DataConection ConnectionDB = new BusinessManager.DataConection();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ConnectionDB.OpenConnection();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loggear(this.textBox1.Text, this.textBox2.Text);
        }

        public void Loggear(string user, string password)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Select UserName FROM [Security].[t_Users] WHERE Password = @pass AND UserName = @User", ConnectionDB.connectDB);
                cmd.Parameters.AddWithValue("User", user);
                cmd.Parameters.AddWithValue("Pass", password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
     

                    Form MDIParentMainMenucs = new MDIParentMainMenucs();
                    MDIParentMainMenucs.Show();
                    this.Hide();

                }
                else {
                    MessageBox.Show("Usuario Incorrecto!");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
