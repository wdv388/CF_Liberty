using CF_Liberty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_Liberty.Controllers
{
    public class HomeController : Controller
    {
        private Contextliberty db = new Contextliberty();
           

        public ActionResult Addbook()
        {
            ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName");
             
            return View(); 
           
        }
        [HttpPost]
        public ActionResult Addbook(Book book)
        {
            if (Request.IsAjaxRequest())
            {
               
                return PartialView();
            }

            else
            {
                
                ViewBag.AuthorId = new SelectList(db.authors, "ID", "FirstName", book.AuthorId);
                db.books.Add(book);
                db.SaveChanges();
                return View(book);    
            }
               
            
        }
        
       
    }
}
