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
            List<string> errorMessages = new List<string>();
            if (!validation.IsBookNameValid(book.bookName))
            {
               errorMessages.Add("ERROR!!! Enter Valid Book Name");
            }

            if(!validation.IsAuthorNameValid(book.authorName))
            {
                errorMessages.Add("ERROR!!! Enter Valid Author Name");
            }

            if(validation.IsInputNegative(book.isbnNumber))
            {
                errorMessages.Add("ERROR!!! Enter positive ISBN Number");
            }
            
            if(!validation.IsPriceValid(book.price))
            {
                errorMessages.Add("ERROR!!! Enter positive value for price");
            }

            if (errorMessages.Count > 0)
                return string.Join(",", errorMessages.ToArray());
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
