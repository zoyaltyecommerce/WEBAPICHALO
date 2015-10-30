using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHALO.Controllers
{
    public class profileController : ApiController
    {
        public IHttpActionResult GetLogin(string name, string userid)
        {
            CHALOEntities db = new CHALOEntities();
            CH_USER objuser = new CH_USER();
            int pareseduser = Int32.Parse(userid);
            objuser = db.CH_USER.Where(s => s.USER_ID == pareseduser).FirstOrDefault<CH_USER>();

            objuser.USER_COUPONAPPLIED = true;

            objuser.USER_FIRSTNAME = name;
            db.Entry(objuser).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            List<CH_USER> list = db.Database.SqlQuery<CH_USER>("select * from ch_user where USER_ID="+ userid +" and user_status=1").ToList();
      
            // List<LOCATION> users = new List<LOCATION>();
        
            //return CreatedAtRoute("DefaultApi", new { id = users[0].USER_ID }, users);
            //CH_USER cH_USER = db.CH_USER.Find(userid);
            //if (cH_USER == null)
            //{
            //    return NotFound();
            //}

            return Ok(list);
        }
       
        //public IHttpActionResult UpdateName(string name, string userid)
        //{
        //    CHALOEntities db = new CHALOEntities();
        //    CH_USER objuser = new CH_USER();
        //    int pareseduser = Int32.Parse(userid);
        //    objuser = db.CH_USER.Where(s => s.USER_ID == pareseduser).FirstOrDefault<CH_USER>();

        //    objuser.USER_COUPONAPPLIED = true;

        //    objuser.USER_FIRSTNAME = name;
        //    db.Entry(objuser).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
            

        //    return Json(new { Success = "success" });
        
        //}
    }
}
