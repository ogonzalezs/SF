using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Customers
{
    public partial class Frm_MainCustomer : Form
    {
        public Frm_MainCustomer()
        {
            InitializeComponent();
        }

        private void Frm_MainCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saleForceDBDataSet.t_Customers' table. You can move, or remove it, as needed.
            this.t_CustomersTableAdapter.Fill(this.saleForceDBDataSet.t_Customers);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.t_CustomersTableAdapter.FillBy(this.saleForceDBDataSet.t_Customers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frmCustomer = new Frm_Customer();
            frmCustomer.Show();
        }
    }
}
