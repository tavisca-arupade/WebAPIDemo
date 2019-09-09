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

        ErrorData errorData = new ErrorData();


        public IEnumerable<Book> GetBooks()
        {
            return _bookList;
        }

        public BookResponseModel AddBook(Book book)
        {
            try
            {
                if (_bookList.Contains(_bookList.Where(b => b.ISBNNumber == book.ISBNNumber).First()))
                    return new BookResponseModel { BookData = null, ErrorData = new List<Error> { errorData.ISBNNumberTakenError } };

            }
            catch (Exception)
            {

                _bookList.Add(book);
                return new BookResponseModel { BookData = GetBookById(book.ISBNNumber).BookData, ErrorData = null };
            }
            return new BookResponseModel { BookData = GetBookById(book.ISBNNumber).BookData, ErrorData = null }; 

        }

        public BookResponseModel UpdateBook(int id,Book book)
        {
            try
            {
                int index = _bookList.IndexOf(_bookList.Where(n => n.ISBNNumber == id).First());
                _bookList[index] = book;
                return new BookResponseModel { BookData = _bookList[index] , ErrorData = null};
            }
            catch (Exception)
            {
                return new BookResponseModel { ErrorData = new List<Error> { errorData.BookNotFoundError } };
            }
           
        }

        public BookResponseModel GetBookById(int id)
        {
            try
            {
                Book book = _bookList.Where(n => n.ISBNNumber == id).First();
                return new BookResponseModel { BookData = book, ErrorData = null };
            }
            catch (Exception)
            {
                return new BookResponseModel { ErrorData = new List<Error> { errorData.BookNotFoundError } };
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
                return new BookResponseModel {ErrorData= new List<Error> { errorData.BookNotFoundError } };
            }
            
        }
    }
}
