using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.Data
{
    public class Orders
    {
        public long DocEntry { get; set; }
        public int DocNum { get; set; }
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public string NumAtCard { get; set; }
        public decimal VatSum { get; set; }
        public decimal DiscSum { get; set; }
        public decimal DocTotal { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Comments { get; set; }
        public int SlpCode { get; set; }
        public int CntctCode { get; set; }
        public DateTime? DateDown { get; set; }
        public long IdCompany { get; set; }
        public List<OrdersDetalle> Detail_ { get; set; }
    }

    public class OrdersDetalle
    {
        public long DocEntry { get; set; }
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string Dscription { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal Price { get; set; }
        public decimal DiscPrcnt { get; set; }
        public decimal LineTotal { get; set; }
        public string WhsCode { get; set; }
        public int SlpCode { get; set; }
        public decimal PriceBefDi { get; set; }
        public decimal PriceAfVAT { get; set; }
        public decimal VatSum { get; set; }
        public string TaxCode { get; set; }
    }
}
