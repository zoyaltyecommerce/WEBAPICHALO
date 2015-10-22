using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHALO.Models;

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

        internal static bool FIRSTUSER100RS(string USERID,string COUPONID)
        { 
            int COUPONUSERID=Convert.ToInt32(USERID);
             if(COUPONID==null || COUPONID=="")
            {
                 COUPONUSERID= 1;
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
            objcoupon.APPLIED_COUPONID=101;
            objcoupon.APPLIED_ADMINCOUPON=true;
            if(COUPONID==null || COUPONID=="")
            {
            objcoupon.APPLIED_COUPONNAME="CHALO-100";
                objcoupon.APPLIED_ADMINCOUPON=true;
                objcoupon.APPLIED_USERCOUPON=false;
                }
            else
            {
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

    }
}