//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CHALO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERTRIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERTRIP()
        {
            this.PAYMENTHISTORies = new HashSet<PAYMENTHISTORY>();
        }
    
        public int USERTRIP_ID { get; set; }
        public Nullable<int> USERTRIP_TRIPID { get; set; }
        public Nullable<int> USERTRIP_PICKUPLOC { get; set; }
        public Nullable<int> USERTRIP_DROPLOC { get; set; }
        public string USERTRIP_VIA { get; set; }
        public Nullable<int> USERTRIP_ESTIMATEDDURATION { get; set; }
        public Nullable<int> USERTRIP_ACTUALDURATION { get; set; }
        public Nullable<int> USERTRIP_DISTANCE { get; set; }
        public Nullable<decimal> USERTRIP_ACTUALAMOUNT { get; set; }
        public Nullable<decimal> USERTRIP_DISCOUNT { get; set; }
        public Nullable<decimal> USERTRIP_TOTALAMOUNT { get; set; }
        public Nullable<int> USERTRIP_STATUS { get; set; }
        public Nullable<int> USERTRIP_CREATEDBY { get; set; }
        public Nullable<System.DateTime> USERTRIP_CREATEDDATE { get; set; }
        public Nullable<int> USERTRIP_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> USERTRIP_MODIFIEDDATE { get; set; }
        public Nullable<int> USERTRIP_APPLIEDCOUPON { get; set; }
        public Nullable<int> USERTRIP_USERID { get; set; }
        public string USERTRIP_APPLIEDCOUPONNAME { get; set; }
    
        public virtual CH_USER CH_USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENTHISTORY> PAYMENTHISTORies { get; set; }
        public virtual TRIPLOCATION TRIPLOCATION { get; set; }
        public virtual TRIPLOCATION TRIPLOCATION1 { get; set; }
        public virtual TRIP TRIP { get; set; }
        public virtual TRIPSTATU TRIPSTATU { get; set; }
    }
}
