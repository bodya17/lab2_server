using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Text;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            using (Context _db = new Context())
            {
                Book b = new Book();
                b.Title = "Some book";
                _db.Books.Add(b);
                _db.SaveChanges();
            }
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AllBooks()
        {
            Context db = new Context();
            var model = db.Books.ToList();
            return View(model);
        }

        public ActionResult SaveBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveBookToDb(string title)
        {
            ///string title = Request["title"].ToString();
            using (Context _db = new Context())
            {
                Book b = new Book();
                b.Title = title;
                _db.Books.Add(b);
                _db.SaveChanges();
            }
            return RedirectToAction("SaveBook");
        }
    }
}