using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
namespace CHALO.Controllers
{
    public class HistoryController : ApiController
    {
        public IHttpActionResult Gethistory(int userid,int tripid)
        {
            CHALOEntities db=new CHALOEntities();

            List<TRIPHISTORYENTITY> list = db.Database.SqlQuery<TRIPHISTORYENTITY>("exec USP_TRIPHISTORY @OPERATION='GETALLTRIPSBYUSERID',@USER_ID='"+ userid +"'").ToList();
           
            return Ok(list);
        }
    }
}


