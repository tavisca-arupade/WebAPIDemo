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
        void AddBook(Book book);
        bool UpdateBook(int id, Book book);
        void DeleteBook(int id);
    }
}
