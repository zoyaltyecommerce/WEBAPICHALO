using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;

namespace CHALO.Controllers
{
    public class SearchController : ApiController
    {
        public IEnumerable<LOCATION> Get()
        {
            CHALOEntities db = new CHALOEntities();
            List<LOCATION> list = db.LOCATIONS.Where(c => c.LOCATION_STATUS==1).ToList().OrderBy(c=>c.LOCATION_NAME).ToList();
            return list;
        }
    }
}
