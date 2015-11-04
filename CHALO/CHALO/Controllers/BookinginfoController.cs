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
using System.IO;

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
            string usertrip = "";
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

                            usertrip=bookride(obj);
                            try
                            { 
                            string mobilenumber =usertrip.Split('$')[1];
                           List<CH_USER> users = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_id='" + obj.userid + "' and user_status=1").ToList();
                            bool statusnew = common.sendmessage("Thank you for choosing CHALO.Your booking has been confirmed.Vehicle number:"+ obj.vehicle_number +", Driver name:"+ obj.driver_name +" ("+ mobilenumber +").Please reach Pickup point("+ obj.fromlocationname +") at least 5 minutes before.Your pick up time is "+ obj.fromactualreachtime +"for any assistance call us at +91 9900036467 or care@chaloindia.net",users[0].USER_MOBILE);
                            }
                            catch(Exception ex)
                            {

                            }
                                //StreamReader reader = new StreamReader(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Emails/registeremail.html")));
                            //string readFile = reader.ReadToEnd();
                            //string myString = "";
                            //myString = readFile;
                            //myString = myString.Replace("$$NAME$$", objuser.USER_FIRSTNAME);
                            //myString = myString.Replace("$$CODE$$", objusercoupon.COUPON_NAME);
                            //bool statusemail = common.sendemail(myString, "Welcome to CHALO", "support@chaloindia.net", objuser.USER_EMAILID);

                            //return Ok(result);
                            return Json(new { Success = usertrip });
                        }
                        else
                        {
                            return Json(new { nowallet = "you have " + objwallet[0].WALLET_AVAILABLEMONEY + " RS in your wallet which is not sufficient to book your cab" });
                        }
                    }
                    else if(obj.paymenttype=="2")
                    {
                         usertrip = bookride(obj);
                        try
                        {
                            string mobilenumber = usertrip.Split('$')[1];
                            List<CH_USER> users = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_id='" + obj.userid + "' and user_status=1").ToList();
                            bool statusnew = common.sendmessage("Thank you for choosing CHALO.Your booking has been confirmed.Vehicle number:" + obj.vehicle_number + ", Driver name:" + obj.driver_name + " (" + mobilenumber + ").Please reach Pickup point(" + obj.fromlocationname + ") at least 5 minutes before.Your pick up time is " + obj.fromactualreachtime + "for any assistance call us at +91 9900036467 or care@chaloindia.net", users[0].USER_MOBILE);
                        }
                        catch (Exception ex)
                        {

                        }
                        return Json(new { Success = usertrip });
                    }
                    else
                    {
                        return Json(new { errorthing = "error" });
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
                return Json(new { errorthing = "error" });
            }



           
        }

        internal string bookride(bookinglist obj)
        {
            CHALOEntities db = new CHALOEntities();
            List<bookeddetails> USERTRIPs = new List<bookeddetails>();
            string result = "";
           // List<USERTRIP> USERTRIPs = new List<USERTRIP>();
            try
            {
                USERTRIPs = db.Database.SqlQuery<bookeddetails>("EXEC USP_BOOKCAB @USER_ID='" + obj.userid + "' ,@USERTRIP_TRIPID='" + obj.trip_id + "',@USERTRIP_PICKUPLOC='" + obj.fromllid + "',@USERTRIP_DROPLOC='" + obj.tollid + "',@USERTRIP_VIA='" + obj.VIA + "',@USERTRIP_ESTIMATEDDURATION='" + obj.duration + "',@USERTRIP_ACTUALDURATION='" + obj.duration + "' ,@USERTRIP_DISTANCE='" + obj.DISTANCE + "',@USERTRIP_ACTUALAMOUNT='" + obj.COST + "',@USERTRIP_DISCOUNT='" + obj.discount + "',@USERTRIP_TOTALAMOUNT='" + obj.totalamount + "',@USERTRIP_STATUS=1,@USERTRIP_APPLIEDCOUPON='" + obj.appliedcoupon + "',@TRANS_STATUS=1 ,@PAYMENTTYPE_ID='" + obj.paymenttype + "' ,@APPLIEDCOUPONNAME ='" + obj.APPLIEDCOUPONNAME + "',@ISONETIME='" + obj.ISONETIME + "',@OPERATION ='BOOKCAB',@usertrip_pickupavergetime='"+ obj.fromaveragereachtimenormal + "',@usertrip_pickupactualtime='"+ obj.fromactualreachtimenormal + "',@usertrip_dropaveragetime='"+ obj.toactualreachtimenormal + "',@usertrip_dropactualtime='"+ obj.toactualreachtimenormal +"'").ToList();
                if(USERTRIPs.Count>0)
                {
                    result = USERTRIPs[0].SUCCESS;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
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
            public DateTime fromaveragereachtimenormal { get; set; }
            public DateTime fromactualreachtimenormal { get; set; }
			 public DateTime  toaveragereachtimenormal { get; set; }
            public DateTime  toactualreachtimenormal { get; set; }
        }

        public class bookeddetails
        {
            public string SUCCESS { get; set; }
        }
    }
}
