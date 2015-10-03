using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class RegisterController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();
       
        public IHttpActionResult Register(string Firstname,string Lastname,string Email,string Pass,string Mobile)
        {
            CH_USER user = new CH_USER();
            //user.USER_FIRSTNAME = Firstname;
            //user.USER_LASTNAME = Lastname;
            //user.USER_EMAILID = Email;
            //user.USER_MOBILE = Mobile;
            //user.USER_PASSWORD = Pass;
            //user.USER_STATUS = 1;
            //user.USER_REGISTERTYPE = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CH_USER.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.USER_ID }, user);
        }
    }
}
