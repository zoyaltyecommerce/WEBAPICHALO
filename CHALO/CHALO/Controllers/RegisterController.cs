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

namespace CHALO.Controllers
{
    public class RegisterController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();

        public IHttpActionResult Register(string Firstname, string Email, string Pass, string Mobile, string code)
        {
            common objcommon = new common();
            CH_USER user = new CH_USER();

            user.USER_FIRSTNAME = Firstname.Trim();
            //user.USER_LASTNAME = Lastname;
            user.USER_EMAILID = Email.Trim();
            user.USER_MOBILE = Mobile.Trim();
            user.USER_PASSWORD = encryptdecrypt.Encrypt(Pass.Trim());
            user.USER_STATUS = 1;
            user.USER_REGISTERTYPE = 1;
            user.USER_MODIFIEDBY = 1;
            user.USER_MODIFIEDDATE = DateTime.Now;
            user.USER_CREATEDBY = 1;
            user.USER_CREATEDATE = DateTime.Now;
            user.USER_USERNAME = Email.Trim();
           
            List<CH_USER> listusers = db.CH_USER.Where(c => c.USER_USERNAME == Email.Trim() || c.USER_MOBILE == Mobile.Trim()).ToList();

            if (listusers.Count > 0)
            {
                return Json(new { id = "userexist" });
            }
            else
            {


                if (code != null && code != "")
                {
                   
                    List<USERCOUPON> listcoupons = db.USERCOUPONS.Where(c => c.COUPON_NAME == code.Trim()).ToList();



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
                       
                        return CreatedAtRoute("DefaultApi", new { id = user.USER_ID }, user);
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

                    return CreatedAtRoute("DefaultApi", new { id = user.USER_ID }, user);
                }

                
            }
        }

      
        
    }
}
