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
    
    public partial class USP_TRIPHISTORY_Result
    {
        public int USERTRIP_ID { get; set; }
        public Nullable<int> USERTRIP_TRIPID { get; set; }
        public int PICKUPID { get; set; }
        public string PICKUPNAME { get; set; }
        public int DROPID { get; set; }
        public string DROPNAME { get; set; }
        public string USERTRIP_VIA { get; set; }
        public Nullable<int> USERTRIP_ACTUALDURATION { get; set; }
        public Nullable<int> USERTRIP_DISTANCE { get; set; }
        public Nullable<decimal> USERTRIP_ACTUALAMOUNT { get; set; }
        public Nullable<decimal> USERTRIP_DISCOUNT { get; set; }
        public Nullable<decimal> USERTRIP_TOTALAMOUNT { get; set; }
        public Nullable<int> USERTRIP_STATUS { get; set; }
        public int USER_ID { get; set; }
        public string USER_FIRSTNAME { get; set; }
        public Nullable<int> USERTRIP_APPLIEDCOUPON { get; set; }
        public string USERTRIP_APPLIEDCOUPONNAME { get; set; }
        public string TRIP_NAME { get; set; }
    }
}