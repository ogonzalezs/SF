//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AT.Integracion.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_CustomerAddress
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
    
        public virtual t_Customer t_Customer { get; set; }
    }
}
