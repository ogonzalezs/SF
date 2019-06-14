using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.Data
{
    public class BusinessPartner
    {
        public string CardCode { get; set; }
        public long IdEmpresa { get; set; }
        public string CardCodeSAP { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string CntctPrsn { get; set; }
        public double Balance { get; set; }
        public double CreditLine { get; set; }
        public string Identificacion { get; set; }
        public int ListNum { get; set; }
        public string Cellular { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string E_Mail { get; set; }
        public string ValidFor { get; set; }
        public List<BusinessPartnerAddress> Direccion { get; set; }
    }

    public class BusinessPartnerAddress
    {
        public long ClienteDireccion { get; set; }
        public long CardCode { get; set; }
        public long IdEmpresa { get; set; }
        public string Tipo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone1 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string E_Mail { get; set; }
        public string ValidFor { get; set; }
    }
}
