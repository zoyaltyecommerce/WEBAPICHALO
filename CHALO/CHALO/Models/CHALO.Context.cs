﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CHALOEntities : DbContext
    {
        public CHALOEntities()
            : base("name=CHALOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CH_USER> CH_USER { get; set; }
        public virtual DbSet<CITy> CITIES { get; set; }
        public virtual DbSet<COUPON> COUPONS { get; set; }
        public virtual DbSet<DRIVER> DRIVERS { get; set; }
        public virtual DbSet<LATLONG> LATLONGS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<MASTERSTATU> MASTERSTATUS { get; set; }
        public virtual DbSet<NOOFSEAT> NOOFSEATS { get; set; }
        public virtual DbSet<PAYMENTTYPE> PAYMENTTYPEs { get; set; }
        public virtual DbSet<ROUTE> ROUTES { get; set; }
        public virtual DbSet<STATE> STATEs { get; set; }
        public virtual DbSet<TRIPLOCATION> TRIPLOCATIONS { get; set; }
        public virtual DbSet<TRIP> TRIPS { get; set; }
        public virtual DbSet<TRIPSTATU> TRIPSTATUS { get; set; }
        public virtual DbSet<USER_REGISTERTYPE> USER_REGISTERTYPE { get; set; }
        public virtual DbSet<USER_STATUS> USER_STATUS { get; set; }
        public virtual DbSet<VEHICLEDRIVER> VEHICLEDRIVERS { get; set; }
        public virtual DbSet<VEHICLE> VEHICLES { get; set; }
        public virtual DbSet<VEHICLETYPE> VEHICLETYPEs { get; set; }
        public virtual DbSet<VENDOR> VENDORS { get; set; }
        public virtual DbSet<temptrip> temptrips { get; set; }
        public virtual DbSet<CHALOWALLET> CHALOWALLETs { get; set; }
        public virtual DbSet<USERTRIP> USERTRIPS { get; set; }
        public virtual DbSet<TRIPTEMP> TRIPTEMPs { get; set; }
        public virtual DbSet<PAYMENTHISTORY> PAYMENTHISTORies { get; set; }
    
        public virtual int USP_LBR_SEARCH(string searchkey, string operation, Nullable<int> lINK_SIGNUPID)
        {
            var searchkeyParameter = searchkey != null ?
                new ObjectParameter("searchkey", searchkey) :
                new ObjectParameter("searchkey", typeof(string));
    
            var operationParameter = operation != null ?
                new ObjectParameter("operation", operation) :
                new ObjectParameter("operation", typeof(string));
    
            var lINK_SIGNUPIDParameter = lINK_SIGNUPID.HasValue ?
                new ObjectParameter("LINK_SIGNUPID", lINK_SIGNUPID) :
                new ObjectParameter("LINK_SIGNUPID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_LBR_SEARCH", searchkeyParameter, operationParameter, lINK_SIGNUPIDParameter);
        }
    
        public virtual int USP_LBR_SIGNUP(string searchkey, string lBR_FIRSTNAME, Nullable<int> lBR_ID, string lBR_LASTNAME, string lBR_EMAILID, string lBR_PASSWORD, string lBR_PHONENUMBER, string lBR_ADDRESS, Nullable<int> lBR_CREATEDBY, Nullable<System.DateTime> lBR_CREATEDDATE, Nullable<int> lBR_MODIFIEDBY, Nullable<System.DateTime> lBR_MODIFIEDDATE, Nullable<int> lBR_MODIFIEDTYPE, Nullable<int> lBR_LOGINTYPE, string lBR_IMAGEURL, string lBR_LOGINID, Nullable<int> lBR_STATUS, string lINK_PATH, string lINK_TITLE, string lINK_DESCRIPTION, Nullable<int> lINK_TYPE, string lINK_DATA, Nullable<int> lINK_STATUS, Nullable<int> lINK_CREATEDBY, Nullable<int> lINK_MODIFIEDBY, string lINK_IMAGEPATH, Nullable<int> lINK_SIGNUPID, Nullable<int> lINK_TABID, Nullable<int> tab_id, Nullable<int> tab_signup_id, string tab_name, Nullable<int> tab_order, Nullable<int> tab_status, Nullable<int> tab_createdby, Nullable<System.DateTime> tab_createddate, Nullable<int> tab_modifiedby, Nullable<System.DateTime> tab_modifieddate, string oPERATION)
        {
            var searchkeyParameter = searchkey != null ?
                new ObjectParameter("searchkey", searchkey) :
                new ObjectParameter("searchkey", typeof(string));
    
            var lBR_FIRSTNAMEParameter = lBR_FIRSTNAME != null ?
                new ObjectParameter("LBR_FIRSTNAME", lBR_FIRSTNAME) :
                new ObjectParameter("LBR_FIRSTNAME", typeof(string));
    
            var lBR_IDParameter = lBR_ID.HasValue ?
                new ObjectParameter("LBR_ID", lBR_ID) :
                new ObjectParameter("LBR_ID", typeof(int));
    
            var lBR_LASTNAMEParameter = lBR_LASTNAME != null ?
                new ObjectParameter("LBR_LASTNAME", lBR_LASTNAME) :
                new ObjectParameter("LBR_LASTNAME", typeof(string));
    
            var lBR_EMAILIDParameter = lBR_EMAILID != null ?
                new ObjectParameter("LBR_EMAILID", lBR_EMAILID) :
                new ObjectParameter("LBR_EMAILID", typeof(string));
    
            var lBR_PASSWORDParameter = lBR_PASSWORD != null ?
                new ObjectParameter("LBR_PASSWORD", lBR_PASSWORD) :
                new ObjectParameter("LBR_PASSWORD", typeof(string));
    
            var lBR_PHONENUMBERParameter = lBR_PHONENUMBER != null ?
                new ObjectParameter("LBR_PHONENUMBER", lBR_PHONENUMBER) :
                new ObjectParameter("LBR_PHONENUMBER", typeof(string));
    
            var lBR_ADDRESSParameter = lBR_ADDRESS != null ?
                new ObjectParameter("LBR_ADDRESS", lBR_ADDRESS) :
                new ObjectParameter("LBR_ADDRESS", typeof(string));
    
            var lBR_CREATEDBYParameter = lBR_CREATEDBY.HasValue ?
                new ObjectParameter("LBR_CREATEDBY", lBR_CREATEDBY) :
                new ObjectParameter("LBR_CREATEDBY", typeof(int));
    
            var lBR_CREATEDDATEParameter = lBR_CREATEDDATE.HasValue ?
                new ObjectParameter("LBR_CREATEDDATE", lBR_CREATEDDATE) :
                new ObjectParameter("LBR_CREATEDDATE", typeof(System.DateTime));
    
            var lBR_MODIFIEDBYParameter = lBR_MODIFIEDBY.HasValue ?
                new ObjectParameter("LBR_MODIFIEDBY", lBR_MODIFIEDBY) :
                new ObjectParameter("LBR_MODIFIEDBY", typeof(int));
    
            var lBR_MODIFIEDDATEParameter = lBR_MODIFIEDDATE.HasValue ?
                new ObjectParameter("LBR_MODIFIEDDATE", lBR_MODIFIEDDATE) :
                new ObjectParameter("LBR_MODIFIEDDATE", typeof(System.DateTime));
    
            var lBR_MODIFIEDTYPEParameter = lBR_MODIFIEDTYPE.HasValue ?
                new ObjectParameter("LBR_MODIFIEDTYPE", lBR_MODIFIEDTYPE) :
                new ObjectParameter("LBR_MODIFIEDTYPE", typeof(int));
    
            var lBR_LOGINTYPEParameter = lBR_LOGINTYPE.HasValue ?
                new ObjectParameter("LBR_LOGINTYPE", lBR_LOGINTYPE) :
                new ObjectParameter("LBR_LOGINTYPE", typeof(int));
    
            var lBR_IMAGEURLParameter = lBR_IMAGEURL != null ?
                new ObjectParameter("LBR_IMAGEURL", lBR_IMAGEURL) :
                new ObjectParameter("LBR_IMAGEURL", typeof(string));
    
            var lBR_LOGINIDParameter = lBR_LOGINID != null ?
                new ObjectParameter("LBR_LOGINID", lBR_LOGINID) :
                new ObjectParameter("LBR_LOGINID", typeof(string));
    
            var lBR_STATUSParameter = lBR_STATUS.HasValue ?
                new ObjectParameter("LBR_STATUS", lBR_STATUS) :
                new ObjectParameter("LBR_STATUS", typeof(int));
    
            var lINK_PATHParameter = lINK_PATH != null ?
                new ObjectParameter("LINK_PATH", lINK_PATH) :
                new ObjectParameter("LINK_PATH", typeof(string));
    
            var lINK_TITLEParameter = lINK_TITLE != null ?
                new ObjectParameter("LINK_TITLE", lINK_TITLE) :
                new ObjectParameter("LINK_TITLE", typeof(string));
    
            var lINK_DESCRIPTIONParameter = lINK_DESCRIPTION != null ?
                new ObjectParameter("LINK_DESCRIPTION", lINK_DESCRIPTION) :
                new ObjectParameter("LINK_DESCRIPTION", typeof(string));
    
            var lINK_TYPEParameter = lINK_TYPE.HasValue ?
                new ObjectParameter("LINK_TYPE", lINK_TYPE) :
                new ObjectParameter("LINK_TYPE", typeof(int));
    
            var lINK_DATAParameter = lINK_DATA != null ?
                new ObjectParameter("LINK_DATA", lINK_DATA) :
                new ObjectParameter("LINK_DATA", typeof(string));
    
            var lINK_STATUSParameter = lINK_STATUS.HasValue ?
                new ObjectParameter("LINK_STATUS", lINK_STATUS) :
                new ObjectParameter("LINK_STATUS", typeof(int));
    
            var lINK_CREATEDBYParameter = lINK_CREATEDBY.HasValue ?
                new ObjectParameter("LINK_CREATEDBY", lINK_CREATEDBY) :
                new ObjectParameter("LINK_CREATEDBY", typeof(int));
    
            var lINK_MODIFIEDBYParameter = lINK_MODIFIEDBY.HasValue ?
                new ObjectParameter("LINK_MODIFIEDBY", lINK_MODIFIEDBY) :
                new ObjectParameter("LINK_MODIFIEDBY", typeof(int));
    
            var lINK_IMAGEPATHParameter = lINK_IMAGEPATH != null ?
                new ObjectParameter("LINK_IMAGEPATH", lINK_IMAGEPATH) :
                new ObjectParameter("LINK_IMAGEPATH", typeof(string));
    
            var lINK_SIGNUPIDParameter = lINK_SIGNUPID.HasValue ?
                new ObjectParameter("LINK_SIGNUPID", lINK_SIGNUPID) :
                new ObjectParameter("LINK_SIGNUPID", typeof(int));
    
            var lINK_TABIDParameter = lINK_TABID.HasValue ?
                new ObjectParameter("LINK_TABID", lINK_TABID) :
                new ObjectParameter("LINK_TABID", typeof(int));
    
            var tab_idParameter = tab_id.HasValue ?
                new ObjectParameter("tab_id", tab_id) :
                new ObjectParameter("tab_id", typeof(int));
    
            var tab_signup_idParameter = tab_signup_id.HasValue ?
                new ObjectParameter("tab_signup_id", tab_signup_id) :
                new ObjectParameter("tab_signup_id", typeof(int));
    
            var tab_nameParameter = tab_name != null ?
                new ObjectParameter("tab_name", tab_name) :
                new ObjectParameter("tab_name", typeof(string));
    
            var tab_orderParameter = tab_order.HasValue ?
                new ObjectParameter("tab_order", tab_order) :
                new ObjectParameter("tab_order", typeof(int));
    
            var tab_statusParameter = tab_status.HasValue ?
                new ObjectParameter("tab_status", tab_status) :
                new ObjectParameter("tab_status", typeof(int));
    
            var tab_createdbyParameter = tab_createdby.HasValue ?
                new ObjectParameter("tab_createdby", tab_createdby) :
                new ObjectParameter("tab_createdby", typeof(int));
    
            var tab_createddateParameter = tab_createddate.HasValue ?
                new ObjectParameter("tab_createddate", tab_createddate) :
                new ObjectParameter("tab_createddate", typeof(System.DateTime));
    
            var tab_modifiedbyParameter = tab_modifiedby.HasValue ?
                new ObjectParameter("tab_modifiedby", tab_modifiedby) :
                new ObjectParameter("tab_modifiedby", typeof(int));
    
            var tab_modifieddateParameter = tab_modifieddate.HasValue ?
                new ObjectParameter("tab_modifieddate", tab_modifieddate) :
                new ObjectParameter("tab_modifieddate", typeof(System.DateTime));
    
            var oPERATIONParameter = oPERATION != null ?
                new ObjectParameter("OPERATION", oPERATION) :
                new ObjectParameter("OPERATION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_LBR_SIGNUP", searchkeyParameter, lBR_FIRSTNAMEParameter, lBR_IDParameter, lBR_LASTNAMEParameter, lBR_EMAILIDParameter, lBR_PASSWORDParameter, lBR_PHONENUMBERParameter, lBR_ADDRESSParameter, lBR_CREATEDBYParameter, lBR_CREATEDDATEParameter, lBR_MODIFIEDBYParameter, lBR_MODIFIEDDATEParameter, lBR_MODIFIEDTYPEParameter, lBR_LOGINTYPEParameter, lBR_IMAGEURLParameter, lBR_LOGINIDParameter, lBR_STATUSParameter, lINK_PATHParameter, lINK_TITLEParameter, lINK_DESCRIPTIONParameter, lINK_TYPEParameter, lINK_DATAParameter, lINK_STATUSParameter, lINK_CREATEDBYParameter, lINK_MODIFIEDBYParameter, lINK_IMAGEPATHParameter, lINK_SIGNUPIDParameter, lINK_TABIDParameter, tab_idParameter, tab_signup_idParameter, tab_nameParameter, tab_orderParameter, tab_statusParameter, tab_createdbyParameter, tab_createddateParameter, tab_modifiedbyParameter, tab_modifieddateParameter, oPERATIONParameter);
        }
    
        public virtual int USP_SEARCHVEHICLES(string dROPLOCATION, string pICKUPLOCATION)
        {
            var dROPLOCATIONParameter = dROPLOCATION != null ?
                new ObjectParameter("DROPLOCATION", dROPLOCATION) :
                new ObjectParameter("DROPLOCATION", typeof(string));
    
            var pICKUPLOCATIONParameter = pICKUPLOCATION != null ?
                new ObjectParameter("PICKUPLOCATION", pICKUPLOCATION) :
                new ObjectParameter("PICKUPLOCATION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_SEARCHVEHICLES", dROPLOCATIONParameter, pICKUPLOCATIONParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> USP_BOOKTRIP(Nullable<int> uSERTRIP_ID, Nullable<int> uSERTRIP_TRIPID, Nullable<int> uSERTRIP_PICKUPLOC, Nullable<int> uSERTRIP_DROPLOC, string uSERTRIP_VIA, Nullable<int> uSERTRIP_ESTIMATEDDURATION, Nullable<int> uSERTRIP_ACTUALDURATION, Nullable<int> uSERTRIP_DISTANCE, Nullable<decimal> uSERTRIP_ACTUALAMOUNT, Nullable<decimal> uSERTRIP_DISCOUNT, Nullable<decimal> uSERTRIP_TOTALAMOUNT, Nullable<int> uSERTRIP_STATUS, string uSERTRIP_APPLIEDCOUPON, Nullable<int> uSERTRIP_CREATEDBY, Nullable<System.DateTime> uSERTRIP_CREATEDDATE, Nullable<int> uSERTRIP_MODIFIEDBY, Nullable<System.DateTime> uSERTRIP_MODIFIEDDATE, string oPERATION)
        {
            var uSERTRIP_IDParameter = uSERTRIP_ID.HasValue ?
                new ObjectParameter("USERTRIP_ID", uSERTRIP_ID) :
                new ObjectParameter("USERTRIP_ID", typeof(int));
    
            var uSERTRIP_TRIPIDParameter = uSERTRIP_TRIPID.HasValue ?
                new ObjectParameter("USERTRIP_TRIPID", uSERTRIP_TRIPID) :
                new ObjectParameter("USERTRIP_TRIPID", typeof(int));
    
            var uSERTRIP_PICKUPLOCParameter = uSERTRIP_PICKUPLOC.HasValue ?
                new ObjectParameter("USERTRIP_PICKUPLOC", uSERTRIP_PICKUPLOC) :
                new ObjectParameter("USERTRIP_PICKUPLOC", typeof(int));
    
            var uSERTRIP_DROPLOCParameter = uSERTRIP_DROPLOC.HasValue ?
                new ObjectParameter("USERTRIP_DROPLOC", uSERTRIP_DROPLOC) :
                new ObjectParameter("USERTRIP_DROPLOC", typeof(int));
    
            var uSERTRIP_VIAParameter = uSERTRIP_VIA != null ?
                new ObjectParameter("USERTRIP_VIA", uSERTRIP_VIA) :
                new ObjectParameter("USERTRIP_VIA", typeof(string));
    
            var uSERTRIP_ESTIMATEDDURATIONParameter = uSERTRIP_ESTIMATEDDURATION.HasValue ?
                new ObjectParameter("USERTRIP_ESTIMATEDDURATION", uSERTRIP_ESTIMATEDDURATION) :
                new ObjectParameter("USERTRIP_ESTIMATEDDURATION", typeof(int));
    
            var uSERTRIP_ACTUALDURATIONParameter = uSERTRIP_ACTUALDURATION.HasValue ?
                new ObjectParameter("USERTRIP_ACTUALDURATION", uSERTRIP_ACTUALDURATION) :
                new ObjectParameter("USERTRIP_ACTUALDURATION", typeof(int));
    
            var uSERTRIP_DISTANCEParameter = uSERTRIP_DISTANCE.HasValue ?
                new ObjectParameter("USERTRIP_DISTANCE", uSERTRIP_DISTANCE) :
                new ObjectParameter("USERTRIP_DISTANCE", typeof(int));
    
            var uSERTRIP_ACTUALAMOUNTParameter = uSERTRIP_ACTUALAMOUNT.HasValue ?
                new ObjectParameter("USERTRIP_ACTUALAMOUNT", uSERTRIP_ACTUALAMOUNT) :
                new ObjectParameter("USERTRIP_ACTUALAMOUNT", typeof(decimal));
    
            var uSERTRIP_DISCOUNTParameter = uSERTRIP_DISCOUNT.HasValue ?
                new ObjectParameter("USERTRIP_DISCOUNT", uSERTRIP_DISCOUNT) :
                new ObjectParameter("USERTRIP_DISCOUNT", typeof(decimal));
    
            var uSERTRIP_TOTALAMOUNTParameter = uSERTRIP_TOTALAMOUNT.HasValue ?
                new ObjectParameter("USERTRIP_TOTALAMOUNT", uSERTRIP_TOTALAMOUNT) :
                new ObjectParameter("USERTRIP_TOTALAMOUNT", typeof(decimal));
    
            var uSERTRIP_STATUSParameter = uSERTRIP_STATUS.HasValue ?
                new ObjectParameter("USERTRIP_STATUS", uSERTRIP_STATUS) :
                new ObjectParameter("USERTRIP_STATUS", typeof(int));
    
            var uSERTRIP_APPLIEDCOUPONParameter = uSERTRIP_APPLIEDCOUPON != null ?
                new ObjectParameter("USERTRIP_APPLIEDCOUPON", uSERTRIP_APPLIEDCOUPON) :
                new ObjectParameter("USERTRIP_APPLIEDCOUPON", typeof(string));
    
            var uSERTRIP_CREATEDBYParameter = uSERTRIP_CREATEDBY.HasValue ?
                new ObjectParameter("USERTRIP_CREATEDBY", uSERTRIP_CREATEDBY) :
                new ObjectParameter("USERTRIP_CREATEDBY", typeof(int));
    
            var uSERTRIP_CREATEDDATEParameter = uSERTRIP_CREATEDDATE.HasValue ?
                new ObjectParameter("USERTRIP_CREATEDDATE", uSERTRIP_CREATEDDATE) :
                new ObjectParameter("USERTRIP_CREATEDDATE", typeof(System.DateTime));
    
            var uSERTRIP_MODIFIEDBYParameter = uSERTRIP_MODIFIEDBY.HasValue ?
                new ObjectParameter("USERTRIP_MODIFIEDBY", uSERTRIP_MODIFIEDBY) :
                new ObjectParameter("USERTRIP_MODIFIEDBY", typeof(int));
    
            var uSERTRIP_MODIFIEDDATEParameter = uSERTRIP_MODIFIEDDATE.HasValue ?
                new ObjectParameter("USERTRIP_MODIFIEDDATE", uSERTRIP_MODIFIEDDATE) :
                new ObjectParameter("USERTRIP_MODIFIEDDATE", typeof(System.DateTime));
    
            var oPERATIONParameter = oPERATION != null ?
                new ObjectParameter("OPERATION", oPERATION) :
                new ObjectParameter("OPERATION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("USP_BOOKTRIP", uSERTRIP_IDParameter, uSERTRIP_TRIPIDParameter, uSERTRIP_PICKUPLOCParameter, uSERTRIP_DROPLOCParameter, uSERTRIP_VIAParameter, uSERTRIP_ESTIMATEDDURATIONParameter, uSERTRIP_ACTUALDURATIONParameter, uSERTRIP_DISTANCEParameter, uSERTRIP_ACTUALAMOUNTParameter, uSERTRIP_DISCOUNTParameter, uSERTRIP_TOTALAMOUNTParameter, uSERTRIP_STATUSParameter, uSERTRIP_APPLIEDCOUPONParameter, uSERTRIP_CREATEDBYParameter, uSERTRIP_CREATEDDATEParameter, uSERTRIP_MODIFIEDBYParameter, uSERTRIP_MODIFIEDDATEParameter, oPERATIONParameter);
        }
    
        public virtual int USP_GETVEHICLEBYTRIP(string dROPLOCATION, string pICKUPLOCATION, Nullable<int> tRIP_ID)
        {
            var dROPLOCATIONParameter = dROPLOCATION != null ?
                new ObjectParameter("DROPLOCATION", dROPLOCATION) :
                new ObjectParameter("DROPLOCATION", typeof(string));
    
            var pICKUPLOCATIONParameter = pICKUPLOCATION != null ?
                new ObjectParameter("PICKUPLOCATION", pICKUPLOCATION) :
                new ObjectParameter("PICKUPLOCATION", typeof(string));
    
            var tRIP_IDParameter = tRIP_ID.HasValue ?
                new ObjectParameter("TRIP_ID", tRIP_ID) :
                new ObjectParameter("TRIP_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_GETVEHICLEBYTRIP", dROPLOCATIONParameter, pICKUPLOCATIONParameter, tRIP_IDParameter);
        }
    }
}
