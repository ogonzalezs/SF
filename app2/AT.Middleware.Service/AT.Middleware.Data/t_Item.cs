//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AT.Middleware.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Item()
        {
            this.t_ItemPrice = new HashSet<t_ItemPrice>();
        }
    
        public string ItemCode { get; set; }
        public long IdCompany { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> OnHand { get; set; }
        public Nullable<decimal> IsCommited { get; set; }
        public Nullable<decimal> OnOrder { get; set; }
        public string CardCode { get; set; }
        public string SuppCatNum { get; set; }
        public string BuyUnitMsr { get; set; }
        public Nullable<decimal> NumInBuy { get; set; }
        public string SalUnitMsr { get; set; }
        public Nullable<decimal> NumInSale { get; set; }
        public Nullable<decimal> SHeight1 { get; set; }
        public Nullable<int> SHght1Unit { get; set; }
        public Nullable<decimal> SHeight2 { get; set; }
        public Nullable<int> SHght2Unit { get; set; }
        public Nullable<decimal> SWidth1 { get; set; }
        public Nullable<int> SWdth1Unit { get; set; }
        public Nullable<decimal> SWidth2 { get; set; }
        public Nullable<int> SWdth2Unit { get; set; }
        public Nullable<decimal> SLength1 { get; set; }
        public Nullable<int> SLen1Unit { get; set; }
        public Nullable<decimal> Slength2 { get; set; }
        public Nullable<int> SLen2Unit { get; set; }
        public Nullable<decimal> SVolume { get; set; }
        public Nullable<int> SVolUnit { get; set; }
        public Nullable<decimal> SWeight1 { get; set; }
        public Nullable<int> SWght1Unit { get; set; }
        public Nullable<decimal> SWeight2 { get; set; }
        public Nullable<int> SWght2Unit { get; set; }
        public Nullable<decimal> BHeight1 { get; set; }
        public Nullable<int> BHght1Unit { get; set; }
        public Nullable<decimal> BHeight2 { get; set; }
        public Nullable<int> BHght2Unit { get; set; }
        public Nullable<decimal> BWidth1 { get; set; }
        public Nullable<int> BWdth1Unit { get; set; }
        public Nullable<decimal> BWidth2 { get; set; }
        public Nullable<int> BWdth2Unit { get; set; }
        public Nullable<decimal> BLength1 { get; set; }
        public Nullable<int> BLen1Unit { get; set; }
        public Nullable<decimal> Blength2 { get; set; }
        public Nullable<int> BLen2Unit { get; set; }
        public Nullable<decimal> BVolume { get; set; }
        public Nullable<int> BVolUnit { get; set; }
        public Nullable<decimal> BWeight1 { get; set; }
        public Nullable<int> BWght1Unit { get; set; }
        public Nullable<decimal> BWeight2 { get; set; }
        public Nullable<int> BWght2Unit { get; set; }
        public Nullable<int> FirmCode { get; set; }
        public Nullable<System.DateTime> DateDown { get; set; }
        public Nullable<System.DateTime> DateUp { get; set; }
        public System.DateTime sysCreateDate { get; set; }
        public Nullable<System.DateTime> sysUpdateDate { get; set; }
        public Nullable<bool> sysIsDeleted { get; set; }
    
        public virtual t_Company t_Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ItemPrice> t_ItemPrice { get; set; }
    }
}
