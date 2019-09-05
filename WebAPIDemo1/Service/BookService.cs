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

        public IEnumerable<Book> GetBooks()
        {
           return _books.GetBooks();
        }
        public bool AddBook(Book book)
        {
            if (IsBookValid(book))
            {
                _books.AddBook(book);
                return true;
            }
            return false;
        }

        private bool IsBookValid(Book book)
        {
            if (book.bookName is string && book.authorName is string && book.isbnNumber is int && book.price is Double && book.price > 0)
                return true;
            return false;
        }

        public bool UpdateBook(int id, Book book)
        {
            if (id < 0)
                return false;
            return _books.UpdateBook(id, book);
        }

        public bool DeleteBook(int id)
        {
            if (id < 0)
                return false;
            return _books.DeleteBook(id);
        }

        public Book GetBookById(int id)
        {
            return _books.GetBookById(id);
        }
    }
}
