using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
using CHALO.Controllers;

namespace CHALO.Controllers
{
    public class ForgotController : ApiController
    {
        public IHttpActionResult Gethistory(string email,string mobile)
        {
            CHALOEntities db = new CHALOEntities();

            List<CH_USER> list = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_emailid='"+ email +"' or user_mobile='"+ mobile +"'").ToList();

            if (list.Count>0)
            {
             bool status=common.sendmessage("your password","8885629019");
            }
            else
            {

            }
            return Ok(list);
        }
    }
}
