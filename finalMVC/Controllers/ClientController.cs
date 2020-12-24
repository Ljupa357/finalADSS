using finalMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalMVC.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        db_testEntities dbObj = new db_testEntities();
        public ActionResult Client()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClient(tbl_Client model)
        {
            tbl_Client obj = new tbl_Client();
            if (ModelState.IsValid)
            {
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Age = model.Age;
                obj.libraryID = model.libraryID;



                if (model.ID == 0)
                {
                    dbObj.tbl_Client.Add(obj);
                    dbObj.SaveChanges();

                }
                else

                {
                    dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    dbObj.SaveChanges();
                }

            }

            ModelState.Clear();
            return View("Client");

        }
        public ActionResult ClientList()
        {
            var res = dbObj.tbl_Client.ToList();

            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbObj.tbl_Client.Where(x => x.ID == id).First();
            dbObj.tbl_Client.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.tbl_Book.ToList();
            return View("ClientList", list);
        }

    }
}
    
