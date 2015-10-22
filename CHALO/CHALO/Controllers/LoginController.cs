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
           // List<LOCATION> users = new List<LOCATION>();
            try
            {

               users = db.CH_USER.Where(c => c.USER_USERNAME == username && c.USER_PASSWORD == encryptdecrypt.Encrypt(password)).ToList();
               // users = db.LOCATIONS.ToList();
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
      
      
    }
}
