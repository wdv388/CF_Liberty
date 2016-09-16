using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CF_Liberty.Models;

namespace CF_Liberty.Controllers
{ 
    public class BookController : Controller
    {
        private Contextliberty db = new Contextliberty();

        //
        // GET: /Book/

        public ViewResult Index()
        {
            var books = db.books.Include(b => b.author);
            return View(books.ToList());
        }

       
        //
        // GET: /Book/Details/5

        public ViewResult Details(int id)
        {
            Book book = db.books.Find(id);
            return View(book);
        }
     
        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName");
            return View();
        } 

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index", "Author");  
            }

            ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName", book.AuthorId);
            return View(book);
        }
        
        //
        // GET: /Book/Edit/5
 
        public ActionResult Edit(int id)
        {
            Book book = db.books.Find(id);
            ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName", book.AuthorId);
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Author");
            }
            ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName", book.AuthorId);
            return View(book);
        }

        //
        // GET: /Book/Delete/5
 
        public ActionResult Delete(int id)
        {
            Book book = db.books.Find(id);
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Book book = db.books.Find(id);
            db.books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index","Author");
        }

    
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}