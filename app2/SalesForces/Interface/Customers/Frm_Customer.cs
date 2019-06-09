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
    public partial class Frm_Customer : Form
    {
        public Frm_Customer()
        {
            InitializeComponent();
        }

        private void Frm_Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saleForceDBDataSet.t_CardTypes' table. You can move, or remove it, as needed.
            this.t_CardTypesTableAdapter.Fill(this.saleForceDBDataSet.t_CardTypes);

        }
    }
}
