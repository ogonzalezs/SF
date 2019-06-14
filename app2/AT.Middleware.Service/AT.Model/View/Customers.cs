using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class Customers
    {
        public Customers()
        {

        }

        public string CardCode { get; set; }
        public long IdCompany { get; set; }
        public string CardCodeSAP { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string CntctPrsn { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<decimal> CreditLine { get; set; }
        public string Identificacion { get; set; }
        public string ListNum { get; set; }
        public string Cellular { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string E_Mail { get; set; }
        public System.DateTime sysCreateDate { get; set; }
        public Nullable<System.DateTime> sysUpdateDate { get; set; }
        public string validFor { get; set; }
        public Nullable<System.DateTime> DateUp { get; set; }
        public Nullable<System.DateTime> DateDown { get; set; }
        public Nullable<bool> sysIsDeleted { get; set; }

        public virtual ICollection<Customer_Address> Customer_Address { get; set; }
    }
}