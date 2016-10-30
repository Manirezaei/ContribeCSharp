using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        BookStoreEntities _db = new BookStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblCustomer model)
        {
            if(ModelState.IsValid)
            {
                string data = "Book Name :|" + Session["BookName"].ToString() + "| Quantity:|" + Session["Quantity"].ToString() + "| Total Amount:|" + Session["TotalAmount"].ToString() + "|";
              
                tblCustomer _obj = new tblCustomer();
                _obj.InsertCustomerRecord(model.Name, model.Email_Id, model.PhoneNo, model.Address, data);//Insert the customer data to the table

                string bookid = Session["BookId"].ToString();
                int id = int.Parse(bookid);
                tblBook query = (from a in _db.tblBooks where a.Id == id select a).First();
                //Remove the book from list of available books in the DB, after inserting it to the customer's requested book list
                _db.Entry(query).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                string email =model.Email_Id;
                string subject ="Book Order";
                string body =data;
                // Create and send email to the customer for confirmation
                try
                {


                    MailMessage msg = new MailMessage();
                    msg.To.Add(email);
                    msg.From = new MailAddress("manirezaei78@gmail.com");
                    msg.Subject = subject;
                    msg.Body = body;
                    msg.Priority = MailPriority.High;


                    using (SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("manirezaei78@gmail.com", "a44212486");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(msg);
                    }

                    ViewBag.Message = "Email Send Have a Good Day";
                    return RedirectToAction("Index", "SucessOrder");
                }

                catch (Exception ex)
                {
                    ViewBag.Message = "Email Did Not Send Please Try Again";
                }


            }
            return View();
        }
    }
}