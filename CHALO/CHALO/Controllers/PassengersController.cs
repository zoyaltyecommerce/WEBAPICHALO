using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class PassengersController : ApiController
    {
        public IHttpActionResult GETPASSENGERS(string tripid)
        {
            var entityContext = new CHALOEntities();
            List<PASSENGERSENTITY> passengers = entityContext.Database.SqlQuery<PASSENGERSENTITY>("exec [USP_DRIVERSAPP] @TRIP_ID="+ tripid + ",@OPERATION='PASSENGERS'").ToList();
            return Ok(passengers);
        }
    }
}
