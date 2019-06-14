using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class ItemPrices
    {
        public string ItemCode { get; set; }
        public long IdCompany { get; set; }
        public int PriceList { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateUp { get; set; }
        public Nullable<System.DateTime> DateDown { get; set; }
    }
}