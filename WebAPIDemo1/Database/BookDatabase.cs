using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;
using System.Web;
using WebAPIDemo1.Service;

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

        public BookResponseModel AddBook(Book book)
        {
            try
            {
                if (_bookList.Contains(_bookList.Where(b => b.ISBNNumber == book.ISBNNumber).First()))
                    return new BookResponseModel { BookData = null, ErrorData = new List<Error> { new Error { StatusCode = 400, ErrorMessages = "ISBN Number taken" } } };

            }
            catch (Exception)
            {

                _bookList.Add(book);
                return new BookResponseModel { BookData = GetBookById(book.ISBNNumber), ErrorData = null };
            }
            return new BookResponseModel { BookData = GetBookById(book.ISBNNumber), ErrorData = null }; 

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

        public BookResponseModel DeleteBook(int id)
        {
            try
            {
                _bookList.Remove(_bookList.Where(n => n.ISBNNumber == id).First());

                return new BookResponseModel { };
            }
            catch (Exception)
            {
                return new BookResponseModel { };
            }
            
        }
    }
}
