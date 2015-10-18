using CHALO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CHALO.Controllers
{
    public class GetlocationsController : ApiController
    {
        private CHALOEntities db = new CHALOEntities();
      
        public IHttpActionResult GetLogin(string username, string password)
        {
            List<LOCATION> users = new List<LOCATION>();
            try
            {

                users = db.LOCATIONS.ToList();
            }
            catch (Exception ex)
            {

            }
            return Ok(users);
            //CH_USER cH_USER = db.CH_USER.Find(userid);
            //if (cH_USER == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cH_USER);
        }
    }

    }
