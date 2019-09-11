using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo1.Model;

namespace WebAPIDemo1.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        BookResponseModel GetBookById(int id);
        BookResponseModel AddBook(Book book);
        BookResponseModel UpdateBook(int id, Book book);
        BookResponseModel DeleteBook(int id);
    }
}
