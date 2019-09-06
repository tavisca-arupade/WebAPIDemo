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
        BookResponseModel Response = new BookResponseModel();

        public IEnumerable<Book> GetBooks()
        {
           return _books.GetBooks();
        }
        public BookResponseModel AddBook(Book book)
        {
            List<Error> errorMessages = new List<Error>();
            if (!validation.IsNameValid(book.Name))
            {
               errorMessages.Add(new Error { StatusCode = 400,ErrorMessages = "ERROR!!! Enter Valid Book Name" });
            }

            if(!validation.IsAuthorNameValid(book.AuthorName))
            {
                errorMessages.Add(new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter Valid Author Name" });
            }

            if(validation.IsInputNegative(book.ISBNNumber))
            {
                errorMessages.Add(new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter positive ISBN Number" });
            }
            
            if(!validation.IsPriceValid(book.Price))
            {
                errorMessages.Add(new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter positive value for Price" });
            }

            if (errorMessages.Count > 0)
            {
                Response.ErrorData = errorMessages;
            }
            else
            {
                Response = _books.AddBook(book);
            }

            return Response;
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
