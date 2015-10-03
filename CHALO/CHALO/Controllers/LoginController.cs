using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class LoginController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();
        public IHttpActionResult GetLogin(string username, string password)
        {
            List<CH_USER> users = new List<CH_USER>();
            try
            {

                users = db.CH_USER.Where(c => c.USER_USERNAME == username && c.USER_PASSWORD == password).ToList();
            }
            catch (Exception ex)
            {

            }
            return Ok(users);
            //CH_USER cH_USER = db.CH_USER.Find(userid);
            //if (cH_USER == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cH_USER);
        }
        [HttpPost]
        public IHttpActionResult Register(string firstName,string LastName,string Email,string Pass,string Mobile)
        {
            CH_USER user = new CH_USER();
            user.USER_FIRSTNAME = firstName;
            user.USER_LASTNAME = LastName;
            user.USER_EMAILID = Email;
            user.USER_MOBILE = Mobile;
            user.USER_PASSWORD = Pass;
            user.USER_STATUS = 1;
            user.USER_REGISTERTYPE = 1;
            
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
