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
    
    public partial class transaction
    {
        public int TRANS_ID { get; set; }
        public string TRANS_NAME { get; set; }
        public string TRANS_NUMBER { get; set; }
        public Nullable<int> TRANS_MODE { get; set; }
        public string TRANS_MODENAME { get; set; }
        public Nullable<decimal> TRANS_AMOUNT { get; set; }
        public Nullable<int> TRANS_STATUS { get; set; }
        public Nullable<int> TRANS_CREATEDBY { get; set; }
        public Nullable<System.DateTime> TRANS_CRETEATEDDATE { get; set; }
        public Nullable<int> TRANS_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> TRANS_MODIFIEDDATE { get; set; }
        public Nullable<bool> TRANS_CREDIT { get; set; }
        public Nullable<bool> TRANS_DEBIT { get; set; }
    
        public virtual TRANSACTIONMODE TRANSACTIONMODE { get; set; }
        public virtual TRANSACTIONSTATU TRANSACTIONSTATU { get; set; }
    }
}