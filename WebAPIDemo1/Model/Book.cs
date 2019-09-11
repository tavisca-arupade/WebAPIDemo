using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo1.Model
{
    public class Book
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int ISBNNumber { get; set; }
        public double Price { get; set; }

    }
}
