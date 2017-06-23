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
using Empoyee.Models;

namespace Empoyee.Controllers
{
    public class Empolyees1Controller : ApiController
    {
        private EmpoyeeContext db = new EmpoyeeContext();

        // GET: api/Empolyees1
        public IQueryable<Empolyee> GetEmpolyees()
        {
            return db.Empolyees;
        }
        
        // GET: api/Empolyees1/5
        [ResponseType(typeof(Empolyee))]
        public IHttpActionResult GetEmpolyee(int id)
        {
            Empolyee empolyee = db.Empolyees.Find(id);
            if (empolyee == null)
            {
                return NotFound();
            }

            return Ok(empolyee);
        }

        // PUT: api/Empolyees1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpolyee(int id, Empolyee empolyee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empolyee.ID)
            {
                return BadRequest();
            }

            db.Entry(empolyee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpolyeeExists(id))
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

        // POST: api/Empolyees1
        [ResponseType(typeof(Empolyee))]
        public IHttpActionResult PostEmpolyee(Empolyee empolyee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empolyees.Add(empolyee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empolyee.ID }, empolyee);
        }

        // DELETE: api/Empolyees1/5
        [ResponseType(typeof(Empolyee))]
        public IHttpActionResult DeleteEmpolyee(int id)
        {
            Empolyee empolyee = db.Empolyees.Find(id);
            if (empolyee == null)
            {
                return NotFound();
            }

            db.Empolyees.Remove(empolyee);
            db.SaveChanges();

            return Ok(empolyee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpolyeeExists(int id)
        {
            return db.Empolyees.Count(e => e.ID == id) > 0;
        }
    }
}