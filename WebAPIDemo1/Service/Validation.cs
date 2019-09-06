using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;
using System.Text.RegularExpressions;

namespace WebAPIDemo1.Service
{
    public class Validation
    {
        public bool IsInputNegative(int id) => (id < 0) ? true : false;

        public bool IsDataValid(Book book)
        {
            if (IsBookNameValid(book.bookName) && IsAuthorNameValid(book.authorName) && !IsInputNegative(book.isbnNumber) && IsPriceValid(book.price))
                return true;
            return false;
        }

        public bool IsPriceValid(double price)
        {
            return (price > 0) ? true : false;
        }

        public bool IsAuthorNameValid(string authorName)
        {
           return Regex.IsMatch(authorName, @"^[a-zA-Z\s]+$");
        }

        public bool IsBookNameValid(string bookName)
        {
            return !string.IsNullOrEmpty(bookName);
        }
    }
}
