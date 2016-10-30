using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class HomeController : Controller
    {
     
        BookStoreEntities _db = new BookStoreEntities();
        // Get list of books from the table
        public ActionResult Index()
        {
           
            ViewBag.data = _db.tblBooks.ToList().Take(4);//Shows just 4 items of the list
          
           
            return View();
        }
    }
}