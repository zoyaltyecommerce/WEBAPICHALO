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
    
    public partial class USP_GETLOCS_Result
    {
        public int LOCATION_ID { get; set; }
        public Nullable<int> LOCATION_CITYID { get; set; }
        public string LOCATION_NAME { get; set; }
        public Nullable<decimal> LOCATION_LATITUDE { get; set; }
        public Nullable<decimal> LOCATION_LONGITUDE { get; set; }
        public Nullable<int> LOCATION_CREATEDBY { get; set; }
        public Nullable<System.DateTime> LOCATION_CREATEDDATE { get; set; }
        public Nullable<int> LOCATION_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> LOCATION_MODIFIEDDATE { get; set; }
        public Nullable<int> LOCATION_STATUS { get; set; }
    }
}