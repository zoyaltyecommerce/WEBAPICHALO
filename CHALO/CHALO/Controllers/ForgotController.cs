using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
using CHALO.Controllers;
using System.IO;

namespace CHALO.Controllers
{
    public class ForgotController : ApiController
    {
        public IHttpActionResult Gethistory(string email,string mobile)
        {
            CHALOEntities db = new CHALOEntities();
            List<CH_USER> list = new List<CH_USER>();
            if (email!="")
            {
                list = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_emailid='" + email + "' or user_mobile='" + mobile + "'").ToList();
            }
            else if(mobile!="")
            {
                list = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_mobile='" + mobile + "'").ToList();
            }
            if (list.Count>0)
            {
                CH_USER objuser = new CH_USER();
                int pareseduser = (list[0].USER_ID);
                objuser = db.CH_USER.Where(s => s.USER_ID == pareseduser).FirstOrDefault<CH_USER>();
                objuser.USER_COUPONAPPLIED = true;
                string pasword = common.CreatePassword(5);
                objuser.USER_PASSWORD = encryptdecrypt.Encrypt(pasword);
                db.Entry(objuser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                bool status=common.sendmessage("As per your request, Your CHALO password has been changed. "+ pasword +" is your new password,Happily CHALO. ",""+ list[0].USER_MOBILE +"");
                StreamReader reader = new StreamReader(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Emails/forgotemail.html")));
                string readFile = reader.ReadToEnd();
                string myString = "";
                myString = readFile;
                myString = myString.Replace("$$EMAIL$$", list[0].USER_EMAILID);
                myString = myString.Replace("$$PASSWORD$$", pasword);
                bool statusemail = common.sendemail(myString,"Your CHALO password has been reset","support@chaloindia.net",list[0].USER_EMAILID);

            }
            else
            {

            }
            return Ok(list);
        }
    }
}
