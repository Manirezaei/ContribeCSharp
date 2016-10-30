using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookStore.Controllers
{
    public class AddToCartController : Controller
    {
        BookStoreEntities _db = new BookStoreEntities();
        // GET: AddToCart
        public ActionResult Index()
        {
                 
            return View();
        }

       
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pro.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Get book's id from the View in order to insert it to the shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddtoCartItem(int? id)
        {
            // Check if there is any shopping cart, if there is not shopping cart so create it and add the book's id to the created shopping cart
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(_db.tblBooks.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                //If there is shopping cart session, so just use it.
                List<Item> cart = (List<Item>)Session["cart"];
                int booksId = int.Parse(id.ToString());
                int index = isExisting(booksId);//Check if the book already exists in the shopping cart or not 
                if (index == -1)// If the book is not in the cart.
                    cart.Add(new Item(_db.tblBooks.Find(id), 1));
                else // If the book already exist in the cart
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

    }
}