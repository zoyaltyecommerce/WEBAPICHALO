using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class CancelController : ApiController
    {
        public IHttpActionResult Gethistory(string tripid,string userid)
        {
            int? user = Int32.Parse(userid);
            CHALOEntities db = new CHALOEntities();
            List<USERTRIP> list = new List<USERTRIP>();
            int trip = Int32.Parse(tripid);
            USERTRIP objtrip = new USERTRIP();
            objtrip = db.USERTRIPS.Where(s => s.USERTRIP_ID == trip).FirstOrDefault<USERTRIP>();
            objtrip.USERTRIP_STATUS = 4;
            db.Entry(objtrip).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            
            List<TRIPHISTORYENTITY> listtripd = db.Database.SqlQuery<TRIPHISTORYENTITY>("exec USP_TRIPHISTORY @OPERATION='GETALLTRIPSBYTRIPID',@TRIP_ID=" + tripid + "").ToList();
            bool statusnew = common.sendmessage("As per your request, Your booking has been cancelled. Vehicle number:" + listtripd[0].VEHICLENUMBER + ", Driver name:" + listtripd[0].DRIVERNAME + " (" + listtripd[0].DRIVERMOBILE + ") @" + listtripd[0].USERTRIP_PICKUPACTUALTIME + ". For any assistance call us at 9900036467 or care@chaloindia.net", listtripd[0].DRIVERMOBILE);
            PAYMENTHISTORY objhistory = new PAYMENTHISTORY();
            objhistory = db.PAYMENTHISTORies.Where(s => s.PAYMENTHISTORY_USERTRIPID == trip).FirstOrDefault<PAYMENTHISTORY>();
            string message = "";
            if (objhistory.PAYMENTTYPE_ID==1 || objhistory.PAYMENTTYPE_ID == 3)
            {
                message = "Your Booking order has been cancelled";
                decimal? price = objhistory.PAYMENTTYPE_AMOUNTPAID;
                transaction objtrans = new transaction();
                objtrans.TRANS_MODE = 1;
                objtrans.TRANS_CREDIT = true;
                objtrans.TRANS_DEBIT = false;
                objtrans.TRANS_AMOUNT = price;
                objtrans.TRANS_CREATEDBY = user;
                objtrans.TRANS_CRETEATEDDATE = common.getdate();
                objtrans.TRANS_MODENAME = "wallet";
                objtrans.TRANS_MODIFIEDBY = user;
                objtrans.TRANS_MODIFIEDDATE = common.getdate();
                objtrans.TRANS_NAME = "Cancelled amount retrn back";
                objtrans.TRANS_STATUS = 1;
                objtrans.TRANS_USERID = user;
                objtrans = db.transactions.Add(objtrans);
                db.SaveChanges();
                WALLET objwallet = new WALLET();
                objwallet = db.WALLETs.Where(s => s.WALLET_USERID == user).FirstOrDefault<WALLET>();

                WALLETTRANSACTION objwtrans = new WALLETTRANSACTION();
                objwtrans.TRANS_COMMENT = "Cancelled amount return back";
                objwtrans.TRANS_CREATEDBY = user;
                objwtrans.TRANS_CREATEDDATE = common.getdate();
                objwtrans.TRANS_MODIFIEDBY = user;
                objwtrans.TRANS_MODIFIEDDATE = common.getdate();
                objwtrans.TRANS_STATUS = 1;
                objwtrans.TRANS_ID = objtrans.TRANS_ID;
                objwtrans.TRANS_WALLETID = objwallet.WALLET_ID;
                objwtrans.TRANS_WALLETTYPE = 4;
                objwtrans = db.WALLETTRANSACTIONS.Add(objwtrans);
                db.SaveChanges();
                db.Entry(objwallet).State = System.Data.Entity.EntityState.Modified;
                objwallet.WALLET_AVAILABLEMONEY = objwallet.WALLET_AVAILABLEMONEY + price;
                objwallet.WALLET_MODIFIEDBY = user;
                objwallet.WALLET_MODIFIEDDATE = common.getdate();
                db.SaveChanges();
                List<USERTRIP> result = db.Database.SqlQuery<USERTRIP>("select * from usertrips where usertrip_id="+ tripid +"").ToList();
                NOOFSEAT objseats = new NOOFSEAT();
                int? trip_id = result[0].USERTRIP_TRIPID;
                objseats = db.NOOFSEATS.Where(s => s.SEAT_TRIP_ID == trip_id).FirstOrDefault<NOOFSEAT>();
                objseats.SEAT_AVAILABLESEATS = objseats.SEAT_AVAILABLESEATS + 1;
                db.Entry(objseats).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }
            else
            {
                message = "Your Booking order has been cancelled";
            }

            return Json(new { Message = message });
        }
    }

}
