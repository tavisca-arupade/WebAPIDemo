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
        public void AddBook(Book book)
        {
            _books.AddBook(book);
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
            _books.DeleteBook(id);
            return true;
        }

        public Book GetBookById(int id)
        {
            return _books.GetBookById(id);
        }
    }
}
