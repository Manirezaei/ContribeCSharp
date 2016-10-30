using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class DetailController : Controller
    {
        BookStoreEntities _db = new BookStoreEntities();
        /// <summary>
        /// Get the details of a specific book from DB and display it in the view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string id = Session["Id"].ToString();
            int? iid = int.Parse(id);
            if (iid.HasValue)
            {
                var query = (from a in _db.tblBooks where a.Id == iid select a);
                ViewBag.data = query.ToList();
            }

            return View();
        }

        public ActionResult detail(int? id)
        {
            if (id.HasValue)
                Session["Id"] = id;
            return RedirectToAction("Index");
        }


    }
}