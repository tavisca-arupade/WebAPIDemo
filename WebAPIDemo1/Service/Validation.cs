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

        public bool IsPriceValid(double price) => (price > 0) ? true : false;

        public bool IsAuthorNameValid(string authorName) => Regex.IsMatch(authorName, @"^[a-zA-Z\s]+$");

        public bool IsBookNameValid(string bookName) => !string.IsNullOrEmpty(bookName);
    }
}
