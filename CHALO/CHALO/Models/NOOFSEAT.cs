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
    
    public partial class NOOFSEAT
    {
        public int SEAT_ID { get; set; }
        public Nullable<int> SEAT_TRIP_ID { get; set; }
        public Nullable<int> SEAT_ACTUALSEATS { get; set; }
        public Nullable<int> SEAT_AVAILABLESEATS { get; set; }
        public Nullable<int> SEAT_CREATEDBY { get; set; }
        public Nullable<System.DateTime> SEAT_CREATEDDATE { get; set; }
        public Nullable<int> SEAT_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> SEAT_MODIFIEDDATE { get; set; }
    
        public virtual TRIP TRIP { get; set; }
    }
}