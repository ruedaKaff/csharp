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
    public class authorsController : ApiController
    {
        private libraryEntities db = new libraryEntities();

        // GET: api/authors
        public IQueryable<author> Getauthor()
        {
            return db.author;
        }

        // GET: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Getauthor(int id)
        {
            author author = db.author.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthor(int id, author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.id_author)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!authorExists(id))
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

        // POST: api/authors
        [ResponseType(typeof(author))]
        public IHttpActionResult Postauthor(author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.author.Add(author);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = author.id_author }, author);
        }

        // DELETE: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Deleteauthor(int id)
        {
            author author = db.author.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            db.author.Remove(author);
            db.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authorExists(int id)
        {
            return db.author.Count(e => e.id_author == id) > 0;
        }
    }
}