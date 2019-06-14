using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class Customer_Address
    {
        public long CustomerAddress { get; set; }
        public long IdCompany { get; set; }
        public string CardCode { get; set; }
        public string Tipo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone1 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string E_Mail { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string validFor { get; set; }
    }
}