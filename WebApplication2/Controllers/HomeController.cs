using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Text;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteBook(int? bookId)
        {
            using (Context db = new Context())
            {
                Book bookToDelete = db.Books.Where(x => x.BookId == bookId).Select(x => x).FirstOrDefault();
                db.Entry(bookToDelete).State = EntityState.Deleted;
                db.SaveChanges();
                //db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Books]");
            }
            ViewBag.bookId = bookId;
            return View();
        }

        public ActionResult EditBook(int? bookId)
        {

            return Content("Editing " + bookId);
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