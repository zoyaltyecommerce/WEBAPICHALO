using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class SupportController : ApiController
    {
        public IHttpActionResult GetLogin(string subject, string desc, string userid)
        {
            CHALOEntities db = new CHALOEntities();
            SUPPORT objuser = new SUPPORT();
            objuser.SUPPORT_CREATEDBY = 1;
            objuser.SUPPORT_CREATEDDATE = DateTime.Now;
            objuser.SUPPORT_DESCRIPTION = desc;
            objuser.SUPPORT_MODIFIEDBY = 1;
            objuser.SUPPORT_SUBJECT = subject;
            objuser.SUPPORT_USERID = Convert.ToInt32(userid);

            objuser = db.SUPPORTs.Add(objuser);
            db.SaveChanges();

            

            return Ok(objuser);
        }
    }
}
