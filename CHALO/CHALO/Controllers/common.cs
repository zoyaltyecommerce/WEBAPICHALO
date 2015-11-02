using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHALO.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace CHALO.Controllers
{
    public class common
    {
        internal static DateTime getdate()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            return indianTime;

        }
        internal static USERCOUPON addusercoupon(int userid)
        {
            USERCOUPON obj = new USERCOUPON();
            obj.COUPON_USERID = userid;
            //freehunderdwallet
            obj.COUPON_TYPE = 6;
            obj.COUPON_STATUS = 1;
            obj.COUPON_MONEY = 100;
            obj.COUPON_CREATEDBY = 1;
            obj.COUPON_CREATEDDATE = common.getdate();
            obj.COUPON_MODIFIEDBY = 1;
            obj.COUPON_MODIFIEDDATE = common.getdate();
            var dbcontext=new CHALOEntities();
              USERCOUPON objcoupon=dbcontext.USERCOUPONS.Add(obj);
                        dbcontext.SaveChanges();
            return obj;

        }

        internal static bool FIRSTUSER100RS(string USERID,string COUPONID,string couponuserid,int refcouponid)
        {

            int COUPONUSERID =1 ;
             if(COUPONID==null || COUPONID=="")
            {
                 COUPONUSERID= 1;
           }
             else
             {
                 COUPONUSERID = Convert.ToInt32(couponuserid);
             }
           
            CHALOEntities db=new CHALOEntities();
            //coupon applied status
            CH_USER objuser=new CH_USER();
            int pareseduser=Int32.Parse(USERID);
            objuser = db.CH_USER.Where(s => s.USER_ID == pareseduser).FirstOrDefault<CH_USER>();
            
            objuser.USER_COUPONAPPLIED=true;
           
                objuser.USER_REFEREDBY=COUPONUSERID;
           db.Entry(objuser).State = System.Data.Entity.EntityState.Modified; 
            db.SaveChanges();

            //CREATING WALLET FOR USER
            WALLET OBJWALLET=new WALLET();
            OBJWALLET.WALLET_CREATEDBY=1;
            OBJWALLET.WALLET_CREATEDDATE=getdate();
            OBJWALLET.WALLET_MODIFIEDBY=1;
            OBJWALLET.WALLET_MODIFIEDDATE=getdate();
            OBJWALLET.WALLET_STATUS=1;
            OBJWALLET.WALLET_USERID=Int32.Parse(USERID);
            OBJWALLET.WALLET_AVAILABLEMONEY=decimal.Parse("0.00");
          
            OBJWALLET =db.WALLETs.Add(OBJWALLET);
            db.SaveChanges();

            //appliedcouponstableinsert

            APPLIEDCOUPON objcoupon=new APPLIEDCOUPON();

            objcoupon.APPLIED_REFERRALBONUS = false;
            if(COUPONID==null || COUPONID=="")
            {
                objcoupon.APPLIED_COUPONID = 101;
            objcoupon.APPLIED_COUPONNAME="CHALO-100";
                objcoupon.APPLIED_ADMINCOUPON=true;
                objcoupon.APPLIED_USERCOUPON=false;
                }
            else
            {
                objcoupon.APPLIED_COUPONID = refcouponid;
              
            objcoupon.APPLIED_COUPONNAME=COUPONID;
                  objcoupon.APPLIED_ADMINCOUPON=false;
                objcoupon.APPLIED_USERCOUPON=true;
              }
            objcoupon.APPLIED_CREATEDDATE=getdate();
                objcoupon.APPLIED_CREATEDBY=1;
            objcoupon.APPLIED_MODIFIEDBY=1;
            objcoupon.APPLIED_MODIFIEDDATE=getdate();
            objcoupon.APPLIED_ONETIME=true;
            objcoupon.APPLIED_STATUS=1;
           
                 objcoupon.APPLIED_USERID= COUPONUSERID;
            
           objcoupon=db.APPLIEDCOUPONS.Add(objcoupon);
            db.SaveChanges();
            


            //l00rswalletdeposittransaction
            transaction OBJTRANS=new transaction();
            OBJTRANS.TRANS_AMOUNT=decimal.Parse("100.00");
            OBJTRANS.TRANS_CREATEDBY=1;
            OBJTRANS.TRANS_CRETEATEDDATE=getdate();
            OBJTRANS.TRANS_MODE=1;
            OBJTRANS.TRANS_MODENAME="wallet";
            OBJTRANS.TRANS_MODIFIEDBY=1;
            OBJTRANS.TRANS_MODIFIEDDATE=getdate();
            OBJTRANS.TRANS_NAME="CHALO WALLET FIRST TIME USER 100RS";
           OBJTRANS.TRANS_STATUS=1;
           OBJTRANS.TRANS_USERID = Convert.ToInt32(USERID);
           OBJTRANS.TRANS_CREDIT = true;
           OBJTRANS.TRANS_DEBIT = false;
           
            OBJTRANS=ADDTRANS(OBJTRANS);
            db.SaveChanges();

            //
            //ADDING WALLET TRANS
            
            

            WALLETTRANSACTION OBJWALLETTRANS=new WALLETTRANSACTION();
            OBJWALLETTRANS.TRANS_COMMENT="CHALOWALLET FIRSTTIME USER 100";
            OBJWALLETTRANS.TRANS_COUPONAPPLIEDID=objcoupon.APPLIED_ID;
            OBJWALLETTRANS.TRANS_CREATEDBY=1;
            OBJWALLETTRANS.TRANS_CREATEDDATE=getdate();
            OBJWALLETTRANS.TRANS_ID=OBJTRANS.TRANS_ID;
            OBJWALLETTRANS.TRANS_MODIFIEDBY=1;
            OBJWALLETTRANS.TRANS_MODIFIEDDATE=getdate();
            OBJWALLETTRANS.TRANS_STATUS=1;
           OBJWALLETTRANS.TRANS_TRANSACTIONID=OBJTRANS.TRANS_ID;
            OBJWALLETTRANS.TRANS_WALLETID=OBJWALLET.WALLET_ID;
            OBJWALLETTRANS.TRANS_WALLETSTATUS=1;
            OBJWALLETTRANS.TRANS_WALLETTYPE=1;
           OBJWALLETTRANS=db.WALLETTRANSACTIONS.Add(OBJWALLETTRANS);
             db.SaveChanges();

            //adding 100 to wallet
             OBJWALLET = db.WALLETs.Where(s => s.WALLET_ID == OBJWALLET.WALLET_ID).FirstOrDefault<WALLET>();
            OBJWALLET.WALLET_AVAILABLEMONEY=decimal.Parse("100.00");
             db.Entry(OBJWALLET).State = System.Data.Entity.EntityState.Modified; 
             db.SaveChanges();

            //addingwallettoreferredperson
            if(couponuserid!=null && couponuserid!="")
            {
                int cid = Int32.Parse(couponuserid);
                //appliedcouponstableinsert

                APPLIEDCOUPON objcouponref = new APPLIEDCOUPON();
                objcouponref.APPLIED_COUPONID = 101;

                objcouponref.APPLIED_COUPONNAME = objcoupon.APPLIED_COUPONNAME;
                objcouponref.APPLIED_REFERRALBONUS = true;
                objcouponref.APPLIED_COUPONNAME = COUPONID;
                objcouponref.APPLIED_ADMINCOUPON = false;
                objcouponref.APPLIED_USERCOUPON = true;

                objcouponref.APPLIED_CREATEDDATE = getdate();
                objcouponref.APPLIED_CREATEDBY = 1;
                objcouponref.APPLIED_MODIFIEDBY = 1;
                objcouponref.APPLIED_MODIFIEDDATE = getdate();
                objcouponref.APPLIED_ONETIME = true;
                objcouponref.APPLIED_STATUS = 1;

                objcouponref.APPLIED_USERID = COUPONUSERID;

                objcouponref = db.APPLIEDCOUPONS.Add(objcouponref);
                db.SaveChanges();
            

                //l00rswalletdeposittransaction
                transaction OBJTRANSref = new transaction();
                OBJTRANSref.TRANS_AMOUNT = decimal.Parse("100.00");
                OBJTRANSref.TRANS_CREATEDBY = 1;
                OBJTRANSref.TRANS_CRETEATEDDATE = getdate();
                OBJTRANSref.TRANS_MODE = 1;
                OBJTRANSref.TRANS_MODENAME = "wallet";
                OBJTRANSref.TRANS_MODIFIEDBY = 1;
                OBJTRANSref.TRANS_MODIFIEDDATE = getdate();
                OBJTRANSref.TRANS_NAME = "CHALO WALLET refered USER ";
                OBJTRANSref.TRANS_STATUS = 1;
                OBJTRANSref.TRANS_USERID = Convert.ToInt32(couponuserid);
                OBJTRANSref.TRANS_CREDIT = true;
                OBJTRANSref.TRANS_DEBIT = false;
                OBJTRANSref = ADDTRANS(OBJTRANSref);
                db.SaveChanges();

                //ADDING WALLET TRANS


               WALLET objwalletref=db.WALLETs.Where(s => s.WALLET_USERID == cid).FirstOrDefault<WALLET>();

                WALLETTRANSACTION OBJWALLETTRANSref = new WALLETTRANSACTION();
                OBJWALLETTRANSref.TRANS_COMMENT = "CHALOWALLET FIRSTTIME USER 100";
                OBJWALLETTRANSref.TRANS_COUPONAPPLIEDID = objcouponref.APPLIED_ID;
                OBJWALLETTRANSref.TRANS_CREATEDBY = 1;
                OBJWALLETTRANSref.TRANS_CREATEDDATE = getdate();
                OBJWALLETTRANSref.TRANS_ID = OBJTRANS.TRANS_ID;
                OBJWALLETTRANSref.TRANS_MODIFIEDBY = 1;
                OBJWALLETTRANSref.TRANS_MODIFIEDDATE = getdate();
                OBJWALLETTRANSref.TRANS_STATUS = 1;
                OBJWALLETTRANSref.TRANS_TRANSACTIONID = OBJTRANS.TRANS_ID;
                OBJWALLETTRANSref.TRANS_WALLETID = objwalletref.WALLET_ID;
                OBJWALLETTRANSref.TRANS_WALLETSTATUS = 1;
                OBJWALLETTRANSref.TRANS_WALLETTYPE = 1;
                OBJWALLETTRANSref = db.WALLETTRANSACTIONS.Add(OBJWALLETTRANSref);
                db.SaveChanges();

           
            WALLET OBJWALLETREFERRED = db.WALLETs.Where(s => s.WALLET_USERID == cid).FirstOrDefault<WALLET>();
            OBJWALLETREFERRED.WALLET_AVAILABLEMONEY = OBJWALLETREFERRED.WALLET_AVAILABLEMONEY+decimal.Parse("100.00");
            db.Entry(OBJWALLETREFERRED).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            }

             return true;
        }

        internal static transaction  ADDTRANS(transaction OBJTRANS)
        {
            CHALOEntities db=new CHALOEntities();
           transaction OBJTRANSNEW =db.transactions.Add(OBJTRANS);
            db.SaveChanges();
            return OBJTRANSNEW;
        }

        internal static WALLETTRANSACTION ADDWALLETTRANS(WALLETTRANSACTION OBJTRANS)
        {
            CHALOEntities db=new CHALOEntities();
            WALLETTRANSACTION OBJTRANSNEW=db.WALLETTRANSACTIONS.Add(OBJTRANS);
            db.SaveChanges();
            return OBJTRANSNEW;
        }

        internal static bool sendmessage(string message,string mobile)
        {
            bool status = false;
            var request = WebRequest.Create("http://sms99.co.in/pushsms.php?username=trsanthosh&password=K0nnectsu.&sender=CHALOI&message=" + message + "&numbers=" + mobile + "");
            request.ContentType = "text"; //your contentType, Json, text,etc. -- or comment, for text
            request.Method = "GET"; //method, GET, POST, etc -- or comment for GET
            using (WebResponse resp = request.GetResponse())
            {
                if (resp == null)
                { 
                    new Exception("Response is null");

                }
            }
            
            return status;
        }
        internal static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}