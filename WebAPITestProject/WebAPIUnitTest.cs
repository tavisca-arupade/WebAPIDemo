using System;
using System.Collections.Generic;
using WebAPIDemo1.Model;
using Xunit;
using FluentAssertions;
using WebAPIDemo1.Service;

namespace WebAPITestProject
{
    public class WebAPIUnitTest
    {
        [Fact]
        public void Test_GetBooks_should_return_allBooks()
        {
            BookService bookService = new BookService();

            List<Book> _bookList = new List<Book> {
            new Book { Name = "Tide", AuthorName = "Amanda Hocking", ISBNNumber = 12345, Price = 200.0 },
            new Book { Name = "Trylle", AuthorName = "Amanda Hocking", ISBNNumber = 13445, Price = 200.0 }
        };

            Assert.Equal(_bookList.ToString(), bookService.GetBooks().ToString());
        }

        [Fact]
        public void Test_GetBookByID_should_return_book()
        {
            BookService bookService = new BookService();

            Book book = new Book { Name = "Tide", AuthorName = "Amanda Hocking", ISBNNumber = 12345, Price = 200.0 };

            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = book, ErrorData = null }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.GetBookById(12345)));
        }

        [Fact]
        public void Test_whether_book_added_to_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { Name = "Wake", AuthorName = "Amanda Hocking", ISBNNumber = 34590, Price = 200.0 };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData=book,ErrorData=null}), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.AddBook(book)));
        }

        [Fact]
        public void Test_whether_book_data_updated_in_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { Name = "Tide", AuthorName = "Amanda", ISBNNumber = 12345, Price = 200.0 };
            bookService.UpdateBook(12345, book);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = book, ErrorData = null }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.GetBookById(12345)));
        }

        [Fact]
        public void Test_whether_book_deleted_from_database()
        {
            BookService bookService = new BookService();
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Book Not Found" }
            };
            Book book = new Book { Name = "Elegy", AuthorName = "Amanda Hocking", ISBNNumber = 56709, Price = 200.0 };
            bookService.AddBook(book);
            bookService.DeleteBook(56709);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.GetBookById(56709)));
        }

        [Fact]
        public void Test_when_id_is_negative_while_updating_should_return_invalid()
        {
            BookService bookService = new BookService();
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! ID must be Positive" }
            };
            Book book = new Book { Name = "Elegy", AuthorName = "Amanda Hocking", ISBNNumber = 35465, Price = 200.0 };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.UpdateBook(-9,book)));
        }

        [Fact]
        public void Test_when_id_is_negative_while_deleting_should_return_invalid()
        {
            BookService bookService = new BookService();
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! ID must be Positive" }
            };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.DeleteBook(-9)));
        }

        [Fact]
        public void Test_when_updating_book_not_present_should_return_false()
        {
            BookService bookService = new BookService();
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Book Not Found" }
            };
            Book book = new Book { Name = "Wake", AuthorName = "Amanda Hocking", ISBNNumber = 67890, Price = 200.0 };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.UpdateBook(00000, book)));
        }

        [Fact]
        public void Test_when_deleting_book_not_present_should_return_false()
        {
            BookService bookService = new BookService();
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Book Not Found" }
            };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject( bookService.DeleteBook(00000)));
        }


        [Theory]
        [InlineData(400, "ERROR!!! Enter positive value for Price", "Wake", "Amanda Hocking", 12345, -200.0)]
        [InlineData(400,"ERROR!!! Enter positive ISBN Number","Wake", "Amanda Hocking", -12345, 200.0)]
        [InlineData(400,"ERROR!!! Enter Valid Book Name","", "Amanda Hocking", 12345, 200.0)]
        [InlineData(400,"ERROR!!! Enter Valid Author Name","Wake", "Amanda 123", 12345, 200.0)]
        //[InlineData("ERROR!!! Enter Valid Author Name,ERROR!!! Enter positive ISBN Number,ERROR!!! Enter positive value for Price", "Wake", "Amanda 123", -12345, -200.0)]
        public void Test_when_adding_newBook_contains_invalid_data_should_return_false(int statusCode, string errorMessage, string Name, string AuthorName,int ISBNNumber,float Price)
        {
            BookService bookService = new BookService();
            
            Book book = new Book { Name = Name, AuthorName = AuthorName, ISBNNumber = ISBNNumber, Price = Price };
            List<Error> errorList = new List<Error>
            {
                new Error { StatusCode = statusCode, ErrorMessages = errorMessage }
            };
            
            var errorToString = Newtonsoft.Json.JsonConvert.SerializeObject(errorList);         
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.AddBook(book)));
            
        }

        [Fact]
        public void Test_when_adding_newBook_contains_multiple_invalid_data_should_return_false()
        {
            BookService bookService = new BookService();
            
            Book book = new Book { Name = "Wake", AuthorName = "Amanda 123", ISBNNumber = -12345, Price = -200.0 };
            List <Error> errorList = new List<Error>
            {
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter Valid Author Name" },
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter positive ISBN Number" },
                new Error { StatusCode = 400, ErrorMessages = "ERROR!!! Enter positive value for Price" }
            };

            var errorToString = Newtonsoft.Json.JsonConvert.SerializeObject(errorList);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = errorList }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.AddBook(book)));

        }

        [Fact]

        public void Test_when_user_enters_duplicate_ISBNNumber_returns_error_message()
        {
            BookService bookService = new BookService();
            Book book = new Book { Name = "Wake", AuthorName = "Amanda Hocking", ISBNNumber = 12345, Price = 200.0 };
            Error error = new Error { StatusCode = 400, ErrorMessages = "ISBN Number taken" };
            var errorToString = Newtonsoft.Json.JsonConvert.SerializeObject(error);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new BookResponseModel { BookData = null, ErrorData = new List<Error> { error } }), Newtonsoft.Json.JsonConvert.SerializeObject(bookService.AddBook(book)));
        }
    }
}
