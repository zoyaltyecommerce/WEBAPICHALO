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
        public IHttpActionResult Register(List<string> user)
        {
            CH_USER users = new CH_USER();
            //user.USER_FIRSTNAME = Firstname;
            //user.USER_LASTNAME = LastName;
            //user.USER_EMAILID = Email;
            //user.USER_MOBILE = Mobile;
            //user.USER_PASSWORD = Pass;
            //user.USER_STATUS = 1;
            //user.USER_REGISTERTYPE = 1;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CH_USER.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.USER_ID }, user);
        }
    }
}
