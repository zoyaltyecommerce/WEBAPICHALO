using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class SignupController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();
        public IHttpActionResult GetLogin(string Firstname, string Email, string Pass, string Mobile, string code, string regtype, string socialid)
        {
            List<CH_USER> users = new List<CH_USER>();
            // List<LOCATION> users = new List<LOCATION>();
            //try
            //{

            //    if (appid != null && appid != "")
            //    {

            //        users = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_username='" + username + "' and user_status=1").ToList();
            //    }
            //    else
            //    {

            //        users = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_username='" + username + "' and user_password='" + encryptdecrypt.Encrypt(password) + "' and user_status=1").ToList();

            //    }

            //    // users = db.LOCATIONS.ToList();
            //}
            //catch (Exception ex)
            //{

            //}
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
