using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CHALO.Models;
using Newtonsoft.Json.Linq;

namespace CHALO.Controllers
{
    public class BookinginfoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostBookinginfo(bookinglist obj)
        {

            //  List<USERTRIP> list = new List<USERTRIP>();

            CHALOEntities db = new CHALOEntities();
            List<NOOFSEAT> NOOFSEATS = new List<NOOFSEAT>();
            List<WALLET> objwallet = new List<WALLET>();
            // List<LOCATION> users = new List<LOCATION>();
            try
            {

                NOOFSEATS = db.Database.SqlQuery<NOOFSEAT>("EXEC noofseatsavailability @TRIP_ID='" + obj.trip_id + "'").ToList();

                if (NOOFSEATS.Count > 0)
                {
                    if (obj.paymenttype == "1")
                    {
                        objwallet = db.Database.SqlQuery<WALLET>("EXEC CHECKWALLETAMOUNT @USER_ID='" + obj.userid + "'").ToList();
                        if (objwallet[0].WALLET_AVAILABLEMONEY >= obj.totalamount)
                        {
                            List<USERTRIP> usertrip=bookride(obj);
                        }
                        else
                        {
                            return Json(new { nowallet = "you have " + objwallet[0].WALLET_AVAILABLEMONEY + " RS in your wallet whish is not sufficient to book your cab" });
                        }
                    }
                    else if(obj.paymenttype=="2")
                    {
                        List<USERTRIP> usertrip = bookride(obj);
                    }
                }
                else
                {
                    return Json(new { noseats = "seatsover" });
                }
                // users = db.LOCATIONS.ToList();
            }
            catch (Exception ex)
            {

            }



            return CreatedAtRoute("DefaultApi", new { id = "1" }, objwallet);
        }

        internal List<USERTRIP> bookride(bookinglist obj)
        {
            CHALOEntities db = new CHALOEntities();
            List<USERTRIP> USERTRIPs = new List<USERTRIP>();
            try
            {
                USERTRIPs = db.Database.SqlQuery<USERTRIP>("EXEC USP_BOOKCAB @USER_ID='" + obj.userid + "' ,@USERTRIP_TRIPID='" + obj.trip_id + "',@USERTRIP_PICKUPLOC='" + obj.fromllid + "',@USERTRIP_DROPLOC='" + obj.tollid + "',@USERTRIP_VIA='" + obj.VIA + "',@USERTRIP_ESTIMATEDDURATION='" + obj.duration + "',@USERTRIP_ACTUALDURATION='" + obj.duration + "' ,@USERTRIP_DISTANCE='" + obj.DISTANCE + "',@USERTRIP_ACTUALAMOUNT='" + obj.COST + "',@USERTRIP_DISCOUNT='" + obj.discount + "',@USERTRIP_TOTALAMOUNT='" + obj.totalamount + "',@USERTRIP_STATUS=1,@USERTRIP_APPLIEDCOUPON='" + obj.appliedcoupon + "',@TRANS_STATUS=1 ,@PAYMENTTYPE_ID='" + obj.paymenttype + "' ,@APPLIEDCOUPONNAME ='" + obj.APPLIEDCOUPONNAME + "',@ISONETIME='" + obj.ISONETIME + "',@OPERATION ='BOOKCAB'").ToList();

            }
            catch (Exception ex)
            {

            }
            return USERTRIPs;
        }

        public class bookinglist
        {
            public int TRIPTEMP_ID { get; set; }
            public int trip_id { get; set; }
            public string trip_name { get; set; }
            public int trip_vehicle_id { get; set; }
            public int trip_route_id { get; set; }
            public int fromllid { get; set; }
            public string fromlocationname { get; set; }
            public string fromactualreachtime { get; set; }
            public string fromaveragereachtime { get; set; }
            public int tollid { get; set; }
            public string tolocationname { get; set; }
            public string toaveragereachtime { get; set; }
            public string toactualreachtime { get; set; }
            public string startdate { get; set; }
            public string VIA { get; set; }
            public int duration { get; set; }
            public int seat_availableseats { get; set; }
            public int DISTANCE { get; set; }
            public string driver_name { get; set; }
            public string vehicle_number { get; set; }
            public string vehicletype_name { get; set; }
            public decimal COST { get; set; }
            public int userid { get; set; }
            public decimal discount { get; set; }
            public decimal totalamount { get; set; }
            public int appliedcoupon { get; set; }
            public string APPLIEDCOUPONNAME { get; set; }
            public bool ISONETIME { get; set; }

            public string paymenttype { get; set; }
        }
    }
}
