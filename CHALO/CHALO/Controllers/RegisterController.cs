﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
using System.Security.Cryptography;
using System.Text;
using CHALO.Controllers;
using System.IO;

namespace CHALO.Controllers
{
    public class RegisterController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();

        public IHttpActionResult GetLogin(string Firstname, string Email, string Pass, string Mobile, string code,string regtype,string socialid)
        {
            common objcommon = new common();
            CH_USER user = new CH_USER();

            user.USER_FIRSTNAME = Firstname.Trim();
            //user.USER_LASTNAME = Lastname;
            user.USER_EMAILID = Email.Trim();
            user.USER_MOBILE = Mobile.Trim();
            user.USER_PASSWORD = encryptdecrypt.Encrypt(Pass.Trim());
            user.USER_STATUS = 1;
            if(regtype=="" || regtype==null)
            { 
            user.USER_REGISTERTYPE = 1;
            }
            else
            {
                user.USER_REGISTERTYPE = Convert.ToInt32(regtype);
                user.USER_REGID = socialid;
            }
            user.USER_MODIFIEDBY = 1;
            user.USER_MODIFIEDDATE =common.getdate();
            user.USER_CREATEDBY = 1;
            user.USER_CREATEDATE = common.getdate();
            user.USER_USERNAME = Email.Trim();

            List<CH_USER> listusers = db.Database.SqlQuery<CH_USER>("select * from ch_user where user_username='" + Email.Trim() + "' or USER_MOBILE='" + Mobile.Trim() + "'").ToList();

            if (listusers.Count > 0)
            {
                return Json(new { id = "userexist" });
            }
            else
            {


                if (code != null && code != "")
                {
                   
                    List<USERCOUPON> listcoupons = db.Database.SqlQuery<USERCOUPON>("select * from ch_user where coupon_name='" + code.Trim() + "'").ToList();



                    if (listcoupons.Count > 0)
                    {
                        user.USER_REFEREDBY = Convert.ToInt32(listcoupons[0].COUPON_USERID);
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                       CH_USER objuser=db.CH_USER.Add(user);
                        db.SaveChanges();

                        USERCOUPON objusercoupon=common.addusercoupon(objuser.USER_ID);
                         
                        //firsttimeuser
                        bool status = common.FIRSTUSER100RS(objuser.USER_ID.ToString(), code, Convert.ToString(listcoupons[0].COUPON_USERID),listcoupons[0].COUPON_ID);

                        List<CH_USER> result = db.Database.SqlQuery<CH_USER>("select * from ch_user where USER_ID=" + objuser.USER_ID + "").ToList();
                        bool statusnew = common.sendmessage("Welcome to Chalo.Thanks for installing our app!We are delighted with your presence, Have a great ride. Refer your friend with the code " + objusercoupon.COUPON_NAME + " and get 100 RS in your CHALO wallet. For any assistance call us at 9900036467 or email at care@chaloindia.net", "" + objuser.USER_MOBILE + "");
                        StreamReader reader = new StreamReader(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Emails/registeremail.html")));
                        string readFile = reader.ReadToEnd();
                        string myString = "";
                        myString = readFile;
                        myString = myString.Replace("$$NAME$$", objuser.USER_FIRSTNAME);
                        myString = myString.Replace("$$CODE$$", objusercoupon.COUPON_NAME);
                        bool statusemail = common.sendemail(myString, "Welcome to CHALO", "support@chaloindia.net", objuser.USER_EMAILID);

                        return Ok(result);
                    }
                    else
                    {
                        return Json(new { id = "coupondoesnotexist" });
                    }

                    
                }
                else
                {
                   
                    

                    db.CH_USER.Add(user);
                    CH_USER objuser = db.CH_USER.Add(user);
                    db.SaveChanges();
                    USERCOUPON objusercoupon = common.addusercoupon(objuser.USER_ID);
                    bool status = common.FIRSTUSER100RS(objuser.USER_ID.ToString(), "","",0);

                    List<CH_USER> result = db.Database.SqlQuery<CH_USER>("select * from ch_user where USER_ID="+ objuser.USER_ID +"").ToList();
                     bool statusnew = common.sendmessage("Welcome to Chalo.Thanks for installing our app!We are delighted with your presence, Have a great ride. Refer your friend with the code "+ objusercoupon.COUPON_NAME + " and get 100 RS in your CHALO wallet. For any assistance call us at 9900036467 or email at care@chaloindia.net", "" + objuser.USER_MOBILE + "");
                    StreamReader reader = new StreamReader(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/Emails/registeremail.html")));
                    string readFile = reader.ReadToEnd();
                    string myString = "";
                    myString = readFile;
                    myString = myString.Replace("$$NAME$$", objuser.USER_FIRSTNAME);
                    myString = myString.Replace("$$CODE$$", objusercoupon.COUPON_NAME);
                    bool statusemail = common.sendemail(myString, "Welcome to CHALO", "support@chaloindia.net", objuser.USER_EMAILID);

                   
                    return Ok(result);
                }

                
            }
        }

      
        
    }
}
