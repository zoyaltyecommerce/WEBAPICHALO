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
    
    public partial class VENDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENDOR()
        {
            this.DRIVERS = new HashSet<DRIVER>();
            this.VEHICLES = new HashSet<VEHICLE>();
        }
    
        public int VENDOR_ID { get; set; }
        public string VENDOR_ORGANIZATIONNAME { get; set; }
        public string VENDOR_ORGANIZATIONMOBILE { get; set; }
        public string VENDOR_ORGANIZATIONLANDLINE { get; set; }
        public string VENDOR_OWNFIRSTNAME { get; set; }
        public string VENDOR_OWNLASTNAME { get; set; }
        public string VENDOR_CONFIRSTNAME { get; set; }
        public string VENDOR_CONLASTNAME { get; set; }
        public string VENDOR_EMAILID { get; set; }
        public string VENDOR_ADDRESS { get; set; }
        public string VENDOR_OWNMOBILE { get; set; }
        public string VENDOR_CONMOBILE { get; set; }
        public string VENDOR_OWNLANDLINE { get; set; }
        public string VENDOR_CONLANDLINE { get; set; }
        public string VENDOR_USERNAME { get; set; }
        public string VENDOR_PASSWORD { get; set; }
        public Nullable<int> VENDOR_STATUS { get; set; }
        public Nullable<int> VENDOR_CREATEDBY { get; set; }
        public Nullable<System.DateTime> VENDOR_CREATEDDATE { get; set; }
        public Nullable<int> VENDOR_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> VENDOR_MODIFIEDDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRIVER> DRIVERS { get; set; }
        public virtual MASTERSTATU MASTERSTATU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE> VEHICLES { get; set; }
    }
}
