using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHALO.Controllers
{
    public class PromotionsController : ApiController
    {
    //    public IHttpActionResult checkcoupon(string userid)
    //    {
    //        CHALOEntities db = new CHALOEntities();
    //        CH_USER objuser = new CH_USER();
    //        List<USERCOUPON> list = db.Database.SqlQuery<USERCOUPON>("select * from usercoupons where coupon_userid='" + userid + "' ").ToList();
    //        return Ok(list);
    //    }
        public IHttpActionResult GetLogin(string userid)
        {
            CHALOEntities db = new CHALOEntities();
            CH_USER objuser = new CH_USER();
           
          

            List<USERCOUPON> list = db.Database.SqlQuery<USERCOUPON>("select * from usercoupons where coupon_userid=" + userid + " and coupon_status=1").ToList();

            // List<LOCATION> users = new List<LOCATION>();

            //return CreatedAtRoute("DefaultApi", new { id = users[0].USER_ID }, users);
            //CH_USER cH_USER = db.CH_USER.Find(userid);
            //if (cH_USER == null)
            //{
            //    return NotFound();
            //}

            return Ok(list);
        }
    }
}
