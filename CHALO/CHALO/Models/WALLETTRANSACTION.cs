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
    
    public partial class WALLETTRANSACTION
    {
        public int TRANS_ID { get; set; }
        public Nullable<int> TRANS_WALLETID { get; set; }
        public string TRANS_COMMENT { get; set; }
        public Nullable<int> TRANS_WALLETTYPE { get; set; }
        public Nullable<int> TRANS_COUPONAPPLIEDID { get; set; }
        public Nullable<int> TRANS_TRANSACTIONID { get; set; }
        public Nullable<int> TRANS_CREATEDBY { get; set; }
        public Nullable<System.DateTime> TRANS_CREATEDDATE { get; set; }
        public Nullable<int> TRANS_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> TRANS_MODIFIEDDATE { get; set; }
        public Nullable<int> TRANS_STATUS { get; set; }
        public Nullable<int> TRANS_WALLETSTATUS { get; set; }
    
        public virtual WALLET WALLET { get; set; }
        public virtual WALLETADDTYPE WALLETADDTYPE { get; set; }
        public virtual WALLETTRANSACTIONSSTATU WALLETTRANSACTIONSSTATU { get; set; }
        public virtual MASTERSTATU MASTERSTATU { get; set; }
    }
}