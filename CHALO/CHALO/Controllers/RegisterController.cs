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

        public IHttpActionResult Register(string Firstname, string Email, string Pass, string Mobile, string code)
        {
            CH_USER user = new CH_USER();

            user.USER_FIRSTNAME = Firstname.Trim();
            //user.USER_LASTNAME = Lastname;
            user.USER_EMAILID = Email.Trim();
            user.USER_MOBILE = Mobile.Trim();
            user.USER_PASSWORD = Pass.Trim();
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
                    List<COUPON> listcoupons = db.COUPONS.Where(c => c.COUPON_NAME == code.Trim()).ToList();



                    if (listcoupons.Count > 0)
                    {
                        user.USER_REFEREDBY = Convert.ToInt32(listcoupons[0].COUPON_USERID);
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        db.CH_USER.Add(user);
                        db.SaveChanges();

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
                    db.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = user.USER_ID }, user);
                }

                
            }
        }

    }
}
