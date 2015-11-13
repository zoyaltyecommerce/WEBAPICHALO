using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class DrivertripsController : ApiController
    {
        public IHttpActionResult GETtrips(string DRIVERID)
        {
            var entityContext = new CHALOEntities();
            List<DRIVERTRIPSENTITY> listtrips = entityContext.Database.SqlQuery<DRIVERTRIPSENTITY>("exec [USP_DRIVERSAPP] @OPERATION='PENDINGTRIPS',@driver_id=" + DRIVERID + "").ToList();
            return Ok(listtrips);
        }
    }
}