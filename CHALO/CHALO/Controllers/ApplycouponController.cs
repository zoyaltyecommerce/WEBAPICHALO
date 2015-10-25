using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHALO.Controllers
{
    public class ApplycouponController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();
        //public IHttpActionResult Applycoupon(string userid, string coupon)
        //{
        //    List<COUPON>LISTCOUPON =new List<COUPON>();
        //     LISTCOUPON = db.Database.SqlQuery<COUPON>("EXEC USP_CHECKFORCOUPON @USER_ID='"+ userid +"',@COUPONCODE='"+ coupon +"',@OPERATION='CHECKFORCOUPON'").ToList();

        //     return Ok(LISTCOUPON);
        //}
        public IHttpActionResult GetLogin(string username, string password)
        {
            List<COUPONENTIYPURPOSE> users = new List<COUPONENTIYPURPOSE>();
            // List<LOCATION> users = new List<LOCATION>();
            try
            {

                users = db.Database.SqlQuery<COUPONENTIYPURPOSE>("EXEC USP_CHECKFORCOUPON @USER_ID='" + username + "',@COUPONCODE='" + password + "',@OPERATION='CHECKFORCOUPON'").ToList();
                // users = db.LOCATIONS.ToList();
            }
            catch (Exception ex)
            {

            }
            //return CreatedAtRoute("DefaultApi", new { id = users[0].USER_ID }, users);
            //CH_USER cH_USER = db.CH_USER.Find(userid);
            //if (cH_USER == null)
            //{
            //    return NotFound();
            //}

            return Ok(users);
        }

   
    }
}
