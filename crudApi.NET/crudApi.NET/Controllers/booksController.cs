﻿using System;
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
    public class booksController : ApiController
    {
        private libraryEntities db = new libraryEntities();

        // GET: api/books
        public IQueryable<book> Getbook()
        {
            return db.book;
        }

        // GET: api/books/5
        [ResponseType(typeof(book))]
        public IHttpActionResult Getbook(int id)
        {
            book book = db.book.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbook(int id, book book)
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
        [ResponseType(typeof(book))]
        public IHttpActionResult Postbook(book book)
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
        [ResponseType(typeof(book))]
        public IHttpActionResult Deletebook(int id)
        {
            book book = db.book.Find(id);
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