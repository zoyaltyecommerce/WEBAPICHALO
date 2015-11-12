using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
namespace CHALO.Controllers
{
    public class GenerateOTPController : ApiController
    {
        public IHttpActionResult Gethistory(string mobile)
        {
            CHALOEntities db = new CHALOEntities();
            List<DRIVER> users = db.Database.SqlQuery<DRIVER>("select * from drivers where driver_mobile='" + mobile.Trim() + "'").ToList();

            if (users.Count > 0)
            {
                int number = common.generateotp();
                bool statusnew = common.sendmessage("Hello Chalo driver, your OTP is "+ number +"",mobile.Trim());
                return Json(new { otp = number });
            }
            else
            {
                return Ok(users);
            }


            
        }
    }
}
