using System.Collections.Generic;
using WebAPIDemo1.Model;

namespace WebAPIDemo1.Database
{
    public interface IBookDatabase
    {
        IEnumerable<Book> GetBooks();
        BookResponseModel AddBook(Book book);
        BookResponseModel UpdateBook(int id, Book book);
        BookResponseModel GetBookById(int id);
        BookResponseModel DeleteBook(int id);
    }
}
