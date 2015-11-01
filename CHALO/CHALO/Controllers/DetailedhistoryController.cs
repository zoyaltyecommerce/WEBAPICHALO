using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class DetailedhistoryController : ApiController
    {
        public IHttpActionResult Gethistory(string tripid)
        {
            CHALOEntities db = new CHALOEntities();

            List<TRIPHISTORYENTITY> list = db.Database.SqlQuery<TRIPHISTORYENTITY>("exec USP_TRIPHISTORY @OPERATION='GETALLTRIPSBYTRIPID',@TRIP_ID="+ tripid +"").ToList();

            return Ok(list);
        }
    }
}
