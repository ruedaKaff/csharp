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
using crudApi.NET.Models;

namespace crudApi.NET.Controllers
{
    public class publishersController : ApiController
    {
        private libraryEntities db = new libraryEntities();

        // GET: api/publishers
        public IQueryable<publisher> Getpublisher()
        {
            return db.publisher;
        }

        // GET: api/publishers/5
        [ResponseType(typeof(publisher))]
        public IHttpActionResult Getpublisher(int id)
        {
            publisher publisher = db.publisher.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return Ok(publisher);
        }

        // PUT: api/publishers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpublisher(int id, publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publisher.id_publisher)
            {
                return BadRequest();
            }

            db.Entry(publisher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!publisherExists(id))
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

        // POST: api/publishers
        [ResponseType(typeof(publisher))]
        public IHttpActionResult Postpublisher(publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.publisher.Add(publisher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publisher.id_publisher }, publisher);
        }

        // DELETE: api/publishers/5
        [ResponseType(typeof(publisher))]
        public IHttpActionResult Deletepublisher(int id)
        {
            publisher publisher = db.publisher.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }

            db.publisher.Remove(publisher);
            db.SaveChanges();

            return Ok(publisher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool publisherExists(int id)
        {
            return db.publisher.Count(e => e.id_publisher == id) > 0;
        }
    }
}