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
    
    public partial class PAYMENTHISTORY
    {
        public int PAYMENTHISTORY_ID { get; set; }
        public Nullable<int> PAYMENTHISTORY_USERTRIPID { get; set; }
        public Nullable<int> PAYMENTTYPE_ID { get; set; }
        public Nullable<decimal> PAYMENTTYPE_AMOUNTPAID { get; set; }
        public Nullable<int> PAYMENTTYPE_CREATEDBY { get; set; }
        public Nullable<System.DateTime> PAYMENTTYPE_CREATEDDATE { get; set; }
        public Nullable<int> PAYMENT_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> PAYMENTTYPE_MODIFIEDDATE { get; set; }
    
        public virtual USERTRIP USERTRIP { get; set; }
        public virtual PAYMENTTYPE PAYMENTTYPE { get; set; }
    }
}
