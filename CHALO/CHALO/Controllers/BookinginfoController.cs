using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CHALO.Models;
using Newtonsoft.Json.Linq;

namespace CHALO.Controllers
{
    public class BookinginfoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostBookinginfo(bookinglist obj)
        {

            List<USERTRIP> list = new List<USERTRIP>();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.CH_USER.Add(cH_USER);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = "1" }, list);
        }
        public class bookinglist
        {
            public int TRIPTEMP_ID { get; set; }
            public int trip_id { get; set; }
            public string trip_name { get; set; }
            public int trip_vehicle_id { get; set; }
            public int trip_route_id { get; set; }
            public int fromllid { get; set; }
            public string fromlocationname { get; set; }
            public string fromactualreachtime { get; set; }
            public string fromaveragereachtime { get; set; }
            public int tollid { get; set; }
            public string tolocationname { get; set; }
            public string toaveragereachtime { get; set; }
            public string toactualreachtime { get; set; }
            public string startdate { get; set; }
            public string VIA { get; set; }
            public int duration { get; set; }
            public int seat_availableseats { get; set; }
            public int DISTANCE { get; set; }
            public string driver_name { get; set; }
            public string vehicle_number { get; set; }
            public string vehicletype_name { get; set; }
            public decimal COST { get; set; }
        }
    }
}
