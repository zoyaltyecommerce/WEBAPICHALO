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
    
    public partial class WALLETTRANSACTIONSSTATU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WALLETTRANSACTIONSSTATU()
        {
            this.WALLETTRANSACTIONS = new HashSet<WALLETTRANSACTION>();
        }
    
        public int STATUS_ID { get; set; }
        public string STATUS_NAME { get; set; }
        public Nullable<int> STATUS_CREATEDBY { get; set; }
        public Nullable<System.DateTime> STATUS_CREATEDDATE { get; set; }
        public Nullable<int> STATUS_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> STATUS_MODIFIEDDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WALLETTRANSACTION> WALLETTRANSACTIONS { get; set; }
    }
}