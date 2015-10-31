using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Areas;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace CHALO.Controllers
{
    public class SEARCHVIAController : ApiController
    {
        public IHttpActionResult GETVEHICLES(string from, string to)
        {
            var entityContext = new CHALOEntities();
            List<TRIPTEMP> smdetails = entityContext.Database.SqlQuery<TRIPTEMP>("exec USP_SEARCHVEHICLES @DROPLOCATION='" + to + "',@PICKUPLOCATION='" + from + "'").ToList();
            return Ok(smdetails);
        }
      
        public class Translayer
        {

            int trip_id { get; set; }
            //string TRIP_NAME { get; set; }
            //int TRIP_VEHICLE_ID { get; set; }
            //int TRIP_ROUTE_ID { get; set; }
            //int FROMLLID { get; set; }
            //string FROMLOCATIONNAME { get; set; }
            //string FROMAVERAGEREACHTIME { get; set; }
            //string FROMACTUALREACHTIME { get; set; }
            //// int? TOLID { get; set; }
            //string TOLOCATIONNAME { get; set; }
            //string TOAVERAGEREACHTIME { get; set; }
            //string TOACTUALREACHTIME { get; set; }
            //string STARTDATE { get; set; }
            //string VIA { get; set; }
            //int DURATION { get; set; }
            //int SEAT_AVAILABLESEATS { get; set; }
            //int DISTANCE { get; set; }
            //string DRIVER_NAME { get; set; }
            //// string VEHICE_NUMBER { get; set; }
            //string VEHICLETYPE_NAME { get; set; }
            //decimal COST { get; set; }
        }
    }
}
