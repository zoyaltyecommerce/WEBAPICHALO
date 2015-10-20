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
    
    public partial class ROUTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUTE()
        {
            this.TRIPS = new HashSet<TRIP>();
        }
    
        public int ROUTE_ID { get; set; }
        public string ROUTE_NAME { get; set; }
        public string ROUTE_FROMNAME { get; set; }
        public string ROUTE_TONAME { get; set; }
        public string ROUTE_VIANAME { get; set; }
        public Nullable<decimal> ROUTE_FROMLAT { get; set; }
        public Nullable<decimal> ROUTE_TOLAT { get; set; }
        public Nullable<decimal> ROUTE_VIALAT { get; set; }
        public Nullable<decimal> ROUTE_FROMLONG { get; set; }
        public Nullable<decimal> ROUTE_TOLONG { get; set; }
        public Nullable<decimal> ROUTE_VIALONG { get; set; }
        public Nullable<int> ROUTE_CREATEDBY { get; set; }
        public Nullable<System.DateTime> ROUTE_CREATEDDATE { get; set; }
        public Nullable<int> ROUTE_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> ROUTE_MODIFIEDDATE { get; set; }
        public Nullable<int> ROUTE_STATUS { get; set; }
        public string ROUTE_ALLLOCATIONS { get; set; }
    
        public virtual MASTERSTATU MASTERSTATU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRIP> TRIPS { get; set; }
    }
}
