using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class AddBookController : Controller
    {
        
        BookStoreEntities _db = new BookStoreEntities();
        // GET: AddBook
        public ActionResult Index()
        {
            return View();
        }
      
        //Receives one or mulitiple files from view
        [HttpPost]
        public ActionResult Insert(IEnumerable<HttpPostedFileBase> files,tblBook upload )
        {
           
            foreach (var file in files)
            {
                //Check if file is not empty
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                   

                    var  Fname= fileName.Split('.');
                

                    var guid = Guid.NewGuid().ToString();//Create unique id for the file
                    var path = Path.Combine(Server.MapPath("~/uploads"), guid + fileName);//Save data (files) in uploads folder
                    file.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/uploads/" + newpath;

                    if (ModelState.IsValid)
                    { 
                        upload.insertbook(upload.Title, upload.Author, upload.Price, imagepath);//Insert the book's properties to the table  
                           ViewBag.Sucesss = "Your Book has been Inserted";
                        return RedirectToAction("Index");
                        
                    }

                   

                }
            }
            return RedirectToAction("Index");
        }
    }
}