using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;
using System.Web;

namespace WebAPIDemo1.Database
{
    public class BookDatabase
    {
        private static List<Book> _bookList = new List<Book> {
            new Book { Name = "Tide", AuthorName = "Amanda Hocking", ISBNNumber = 12345, Price = 200.0 },
            new Book { Name = "Trylle", AuthorName = "Amanda Hocking", ISBNNumber = 13445, Price = 200.0 }
        };

        public IEnumerable<Book> GetBooks()
        {
            return _bookList;
        }

        public string AddBook(Book book)
        {
            try
            {
                if (_bookList.Contains(_bookList.Where(b => b.ISBNNumber == book.ISBNNumber).First()))
                    return "ISBN Number taken";

            }
            catch (Exception)
            {

                _bookList.Add(book);
                return Newtonsoft.Json.JsonConvert.SerializeObject(GetBookById(book.ISBNNumber));
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(GetBookById(book.ISBNNumber));

        }

        public bool UpdateBook(int id,Book book)
        {
            try
            {
                _bookList[_bookList.IndexOf(_bookList.Where(n => n.ISBNNumber == id).First())] = book;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public Book GetBookById(int id)
        {
            try
            {
                Book book = _bookList.Where(n => n.ISBNNumber == id).First();
                return book;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool DeleteBook(int id)
        {
            try
            {
                _bookList.Remove(_bookList.Where(n => n.ISBNNumber == id).First());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
