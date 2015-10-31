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
        public IEnumerable<LOCATIONENTITY> Get(string type,string from,string city)
        {
            CHALOEntities db = new CHALOEntities();
            // List<LOCATION> list = new List<LOCATION>();
            List<LOCATIONENTITY> list = new List<LOCATIONENTITY>();
            if(type=="city")
            { 
            list = db.Database.SqlQuery<LOCATIONENTITY>("EXEC USP_GETLOCS @OPERATION='CITIES'").ToList();
            }
            else if(type=="from")
            {
                list = db.Database.SqlQuery<LOCATIONENTITY>("EXEC USP_GETLOCS @OPERATION='FROMLOCATIONS',@CITY_NAME='"+ city +"'").ToList();
            }
            else
            {
                list = db.Database.SqlQuery<LOCATIONENTITY>("EXEC USP_GETLOCS @OPERATION='TOLOCATIONS',@CITY_NAME='" + city + "',@FROMLOCATION='"+ from +"'").ToList();
            }
            // List<LOCATION> list = db.LOCATIONS.Where(c => c.LOCATION_STATUS==1).ToList().OrderBy(c=>c.LOCATION_NAME).ToList();

            return list;
        }
        
    }
}
