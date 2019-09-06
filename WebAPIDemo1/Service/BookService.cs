using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Database;
using WebAPIDemo1.Service;

namespace WebAPIDemo1.Model
{
    public class BookService : IBookService
    {
        private BookDatabase _books = new BookDatabase();
        Validation validation = new Validation();

        public IEnumerable<Book> GetBooks()
        {
           return _books.GetBooks();
        }
        public string AddBook(Book book)
        {
            if (!validation.IsBookNameValid(book.bookName))
            {
               return "ERROR!!! Enter Valid Book Name";
            }

            else if(!validation.IsAuthorNameValid(book.authorName))
            {
                return "ERROR!!! Enter Valid Author Name";
            }

            else if(validation.IsInputNegative(book.isbnNumber))
            {
                return "ERROR!!! Enter positive ISBN Number";
            }
            
            else if(!validation.IsPriceValid(book.price))
            {
                return "ERROR!!! Enter positive value for price";
            }
            return _books.AddBook(book);
        }

        public bool UpdateBook(int id, Book book)
        {
            if (validation.IsInputNegative(id))
                return false;
            return _books.UpdateBook(id, book);
        }

        public bool DeleteBook(int id)
        {
            if (validation.IsInputNegative(id))
                return false;
            return _books.DeleteBook(id);
        }

        public Book GetBookById(int id)
        {
            if (validation.IsInputNegative(id))
                return null;
            return _books.GetBookById(id);
        }
    }
}
