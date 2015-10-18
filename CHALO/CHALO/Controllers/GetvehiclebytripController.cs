using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHALO.Controllers
{
    public class GetvehiclebytripController : ApiController
    {
        public IHttpActionResult GETVEHICLES(string trip, string from, string to)
        {
            var entityContext = new CHALOEntities();
            List<TRIPTEMP> listvehicle = entityContext.Database.SqlQuery<TRIPTEMP>("exec [USP_GETVEHICLEBYTRIP] @DROPLOCATION='" + to + "',@PICKUPLOCATION='" + from + "',@TRIP_ID='"+ trip +"'").ToList();
            return Ok(listvehicle);
        }
    }
}