using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.viewModels;

namespace WebApplication1.Controllers
{
    public class bookController : Controller
    {
        // GET: book
        public ActionResult Index()
        {
            List<listBookViewModel>lst;
            using (Entities db= new Entities())
            {
                 lst = (from data in db.book
                           select new listBookViewModel
                           {
                               id_book = data.id_book,
                               name_author = data.name_author,
                               name_publisher = data.name_publisher,
                               title_book = data.title_book,
                               genre_book = data.genre_book,
                               price_book = (float)data.price_book,


                           }).ToList();
            }

            return View(lst);
        }

        public ActionResult newBook() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult newBook(bookViewModel model)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    using (Entities db = new Entities())
                    {
                        var oBook = new book();
                        oBook.name_author = model.name_author;
                        oBook.name_publisher = model.name_publisher;
                        oBook.title_book = model.title_book;
                        oBook.genre_book = model.genre_book;
                        oBook.price_book = model.price_book;

                        db.book.Add(oBook);
                        db.SaveChanges();
                    }
                }
               return Redirect("book/index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}