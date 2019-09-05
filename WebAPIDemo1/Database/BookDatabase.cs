using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;

namespace WebAPIDemo1.Database
{
    public class BookDatabase
    {
        private static List<Book> _bookList = new List<Book> {
            new Book { bookName = "Tide", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 },
            new Book { bookName = "Trylle", authorName = "Amanda Hocking", isbnNumber = 13445, price = 200.0 }
        };

        public IEnumerable<Book> GetBooks()
        {
            return _bookList;
        }

        public void AddBook(Book book)
        {
            _bookList.Add(book);
        }

        public bool UpdateBook(int id,Book book)
        {
            try
            {
                //int index = ;
                _bookList[_bookList.IndexOf(_bookList.Where(n => n.isbnNumber == id).First())] = book;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public Book GetBookById(int id)
        {
            try
            {
                Book book = _bookList.Where(n => n.isbnNumber == id).First();
                return book;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public void DeleteBook(int id)
        {
            _bookList.Remove(_bookList.Where(n => n.isbnNumber == id).First());
        }
    }
}
