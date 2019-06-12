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
    
    public partial class t_Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Orders()
        {
            this.t_OrdersDetail = new HashSet<t_OrdersDetail>();
        }
    
        public long DocEntry { get; set; }
        public long IdCompany { get; set; }
        public int DocNum { get; set; }
        public System.DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public string NumAtCard { get; set; }
        public decimal VatSum { get; set; }
        public decimal DiscSum { get; set; }
        public decimal DocTotal { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Comments { get; set; }
        public Nullable<int> SlpCode { get; set; }
        public Nullable<int> CntctCode { get; set; }
    
        public virtual t_Company t_Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_OrdersDetail> t_OrdersDetail { get; set; }
    }
}
