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
    
    public partial class WALLETADDTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WALLETADDTYPE()
        {
            this.WALLETTRANSACTIONS = new HashSet<WALLETTRANSACTION>();
        }
    
        public int WALLETADD_ID { get; set; }
        public string WALLETADD_NAME { get; set; }
        public Nullable<int> WALLETADD_CREATEDBY { get; set; }
        public Nullable<System.DateTime> WALLETADD_CREATEDDATE { get; set; }
        public Nullable<int> WALLETADD_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> WALLETADD_MODIFIEDDATE { get; set; }
        public Nullable<int> WALLETADD_STATUS { get; set; }
    
        public virtual MASTERSTATU MASTERSTATU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WALLETTRANSACTION> WALLETTRANSACTIONS { get; set; }
    }
}