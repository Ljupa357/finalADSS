using finalMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        db_testEntities dbObj = new db_testEntities();
        public ActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(tbl_Book model)
        {
            tbl_Book obj = new tbl_Book();
            if (ModelState.IsValid)
            {
                obj.idBook = model.idBook;
                obj.bookName = model.bookName;
                obj.Author = model.Author;
                obj.Year = model.Year;



                if (model.idBook == 0)
                {
                    dbObj.tbl_Book.Add(obj);
                    dbObj.SaveChanges();

                }
                else

                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }

            }
            
            ModelState.Clear();
            return View("Book");

        }
        public ActionResult BookList()
        {
            var res = dbObj.tbl_Book.ToList();

            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_Book.Where(x => x.idBook == id).First();
            dbObj.tbl_Book.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_Book.ToList();
            return View("BookList", list);
        }

    }
}