using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    /// <summary>
    /// This class get list of books from DB to display it on the view
    /// </summary>
    public class BookController : Controller
    {
        
        BookStoreEntities _db = new BookStoreEntities();
        public ActionResult Index()
        {
            ViewBag.data = _db.tblBooks.ToList();
            return View();
        }
    }
}