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
    
    public partial class DRIVER
    {
        public int DRIVER_ID { get; set; }
        public string DRIVER_NAME { get; set; }
        public string DRIVER_MOBILE { get; set; }
        public string DRIVER_EMAILID { get; set; }
        public string DRIVER_ALTERNATENUMBER { get; set; }
        public string DRIVER_ADDRESS { get; set; }
        public string DRIVER_USERNAME { get; set; }
        public string DRIVER_PASSWORD { get; set; }
        public string DRIVER_LICENSENUMBER { get; set; }
        public string DRIVER_PANCARD { get; set; }
        public Nullable<int> DRIVER_VENDORID { get; set; }
        public Nullable<int> DRIVER_STATUS { get; set; }
        public Nullable<int> DRIVER_CREATEDBY { get; set; }
        public Nullable<System.DateTime> DRIVER_CREATEDDATE { get; set; }
        public Nullable<int> DRIVER_MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> DRIVER_MODIFIEDDATE { get; set; }
    
        public virtual VENDOR VENDOR { get; set; }
        public virtual MASTERSTATU MASTERSTATU { get; set; }
    }
}