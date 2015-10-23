using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHALO.Models;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CHALO.Controllers
{
    public class SearchController : ApiController
    {
        public IEnumerable<LOCATION> Get()
        {
            CHALOEntities db = new CHALOEntities();
           // List<LOCATION> list = new List<LOCATION>();
            List<LOCATION> list = db.Database.SqlQuery<LOCATION>("EXEC USP_GETLOCS").ToList();
           // List<LOCATION> list = db.LOCATIONS.Where(c => c.LOCATION_STATUS==1).ToList().OrderBy(c=>c.LOCATION_NAME).ToList();
          
            return list;
        }
        
    }
}
