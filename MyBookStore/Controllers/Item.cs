using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.Controllers
{
    public class Item
    {
        BookStoreEntities _db = new BookStoreEntities();
        private tblBook pro = new tblBook();
        private int quantity;

        public Item() { }
        public Item(tblBook pro, int quantity)
        {
            this.Pro = pro;
            this.Quantity = quantity;
        }

        public tblBook Pro
        {
            get
            {
                return pro;
            }

            set
            {
                pro = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}