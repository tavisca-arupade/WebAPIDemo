using FluentValidation.Results;
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
        ErrorData errorData = new ErrorData();

        public IEnumerable<Book> GetBooks()
        {
           return _books.GetBooks();
        }
        public BookResponseModel AddBook(Book book)
        {
            List<Error> errorMessages = new List<Error>();
            ValidationResult result = validation.Validate(book);

            if (!result.IsValid)
            {
                errorMessages = validation.GetErrorList();
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

        public BookResponseModel UpdateBook(int id, Book book)
        {
            if (!validation.IsInputNegative(id))
                Response.ErrorData = new List<Error> { errorData.IDNegativeError };
            else
                Response = _books.UpdateBook(id, book);
            return Response;
        }

        public BookResponseModel DeleteBook(int id)
        {
            if (!validation.IsInputNegative(id))
                Response.ErrorData = new List<Error> { errorData.IDNegativeError };
            else
                Response = _books.DeleteBook(id);
            return Response;
        }

        public BookResponseModel GetBookById(int id)
        {
            if (!validation.IsInputNegative(id))
                Response.ErrorData = new List<Error> { errorData.IDNegativeError };
            else 
                Response = _books.GetBookById(id);
            return Response;
        }

    }
}
