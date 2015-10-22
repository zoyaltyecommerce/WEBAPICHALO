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
    
    public partial class MASTERSTATU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MASTERSTATU()
        {
            this.APPLIEDCOUPONS = new HashSet<APPLIEDCOUPON>();
            this.COUPONS = new HashSet<COUPON>();
            this.COUPONTYPEs = new HashSet<COUPONTYPE>();
            this.USERCOUPONS = new HashSet<USERCOUPON>();
            this.WALLETs = new HashSet<WALLET>();
            this.WALLETADDTYPES = new HashSet<WALLETADDTYPE>();
            this.WALLETTRANSACTIONS = new HashSet<WALLETTRANSACTION>();
            this.CITIES = new HashSet<CITy>();
            this.DRIVERS = new HashSet<DRIVER>();
            this.LOCATIONS = new HashSet<LOCATION>();
            this.ROUTES = new HashSet<ROUTE>();
            this.STATEs = new HashSet<STATE>();
            this.VEHICLES = new HashSet<VEHICLE>();
            this.VENDORS = new HashSet<VENDOR>();
        }
    
        public int STATUS_ID { get; set; }
        public string SATUS_NAME { get; set; }
        public Nullable<int> STATUS_CREATEDBY { get; set; }
        public Nullable<System.DateTime> STATUS_CREATEDDATE { get; set; }
        public Nullable<int> STATUS_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> STATUS_MODIFIEDDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPLIEDCOUPON> APPLIEDCOUPONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COUPON> COUPONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COUPONTYPE> COUPONTYPEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERCOUPON> USERCOUPONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WALLET> WALLETs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WALLETADDTYPE> WALLETADDTYPES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WALLETTRANSACTION> WALLETTRANSACTIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITy> CITIES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRIVER> DRIVERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTE> ROUTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATE> STATEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE> VEHICLES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDOR> VENDORS { get; set; }
    }
}
