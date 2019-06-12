using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class RDR1
    {
        public int DocEntry { get; set; }
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string Dscription { get; set; }
        public double Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public double Price { get; set; }
        public double DiscPrcnt { get; set; }
        public double LineTotal { get; set; }
        public string WhsCode { get; set; }
        public int SlpCode { get; set; }
        public double PriceBefDi { get; set; }
        public double PriceAfVAT { get; set; }
        public double VatSum { get; set; }
        public string TaxCode { get; set; }
    }
}
