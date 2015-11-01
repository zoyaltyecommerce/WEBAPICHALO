using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class WalletController : ApiController
    {
        public IHttpActionResult Gethistory(string userid)
        {
            CHALOEntities db = new CHALOEntities();

            List<WALLET> list = db.Database.SqlQuery<WALLET>("select * from wallet where wallet_userid="+ userid +"").ToList();

            return Ok(list);
        }
    }
}
