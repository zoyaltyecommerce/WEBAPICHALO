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

namespace CHALO.Controllers
{
   
    public class CH_USERController : ApiController
    {
        
        private CHALOEntities db = new CHALOEntities();

        // GET: api/CH
        [ResponseType(typeof(CH_USER))]
        public IEnumerable<CH_USER> Get()
        {
           List<CH_USER> list = db.CH_USER.ToList();
            return list;
        }

        // GET: api/CH_USER/5
        [ResponseType(typeof(CH_USER))]
        public IHttpActionResult GetCH_USER(int id)
        {
            CH_USER cH_USER = db.CH_USER.Find(id);
            if (cH_USER == null)
            {
                return NotFound();
            }

            return Ok(cH_USER);
        }

        // PUT: api/CH_USER/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCH_USER(int id, CH_USER cH_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cH_USER.USER_ID)
            {
                return BadRequest();
            }

            db.Entry(cH_USER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CH_USERExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CH_USER
        [ResponseType(typeof(CH_USER))]
        public IHttpActionResult PostCH_USER(CH_USER cH_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CH_USER.Add(cH_USER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cH_USER.USER_ID }, cH_USER);
        }

        // DELETE: api/CH_USER/5
        [ResponseType(typeof(CH_USER))]
        public IHttpActionResult DeleteCH_USER(int id)
        {
            CH_USER cH_USER = db.CH_USER.Find(id);
            if (cH_USER == null)
            {
                return NotFound();
            }

            db.CH_USER.Remove(cH_USER);
            db.SaveChanges();

            return Ok(cH_USER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CH_USERExists(int id)
        {
            return db.CH_USER.Count(e => e.USER_ID == id) > 0;
        }
    }
}