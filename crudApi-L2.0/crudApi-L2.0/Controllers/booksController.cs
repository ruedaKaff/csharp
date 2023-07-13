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
using crudApi_L2._0.Models;

namespace crudApi_L2._0.Controllers
{
    public class booksController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/books
        public IQueryable<Book> Getbook()
        {
            return db.book;
        }

        // GET: api/books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Getbook(int id)
        {
            Book book = db.book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.id_book)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(id))
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

        // POST: api/books
        [ResponseType(typeof(Book))]
        public IHttpActionResult Postbook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.book.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.id_book }, book);
        }

        // DELETE: api/books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult Deletebook(int id)
        {
            Book book = db.book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.book.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bookExists(int id)
        {
            return db.book.Count(e => e.id_book == id) > 0;
        }
    }
}