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
    
    public partial class APPLIEDCOUPON
    {
        public int APPLIED_ID { get; set; }
        public Nullable<int> APPLIED_USERID { get; set; }
        public Nullable<int> APPLIED_COUPONID { get; set; }
        public string APPLIED_COUPONNAME { get; set; }
        public Nullable<bool> APPLIED_ADMINCOUPON { get; set; }
        public Nullable<bool> APPLIED_USERCOUPON { get; set; }
        public Nullable<bool> APPLIED_ONETIME { get; set; }
        public Nullable<int> APPLIED_CREATEDBY { get; set; }
        public Nullable<System.DateTime> APPLIED_CREATEDDATE { get; set; }
        public Nullable<int> APPLIED_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> APPLIED_MODIFIEDDATE { get; set; }
        public Nullable<int> APPLIED_STATUS { get; set; }
    
        public virtual CH_USER CH_USER { get; set; }
        public virtual MASTERSTATU MASTERSTATU { get; set; }
    }
}
