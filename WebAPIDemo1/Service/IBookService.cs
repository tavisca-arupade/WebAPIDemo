using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;

namespace WebAPIDemo1.Service
{
    interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        bool AddBook(Book book);
        bool UpdateBook(int id, Book book);
        bool DeleteBook(int id);
    }
}
