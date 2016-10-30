using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    interface IBookstoreService
    {
        // Task<IEnumerable<IBook>> GetBooksAsync(string searchString);
        void insertbook(string title, string author, decimal price, string image);
    }
}
