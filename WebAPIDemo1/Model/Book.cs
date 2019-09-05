using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo1.Model
{
    public class Book
    {
        public string bookName { get; set; }
        public string authorName { get; set; }
        public int isbnNumber { get; set; }
        public double price { get; set; }

    }
}
