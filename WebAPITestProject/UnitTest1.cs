using System;
using System.Collections.Generic;
using WebAPIDemo1.Model;
using Xunit;
using FluentAssertions;

namespace WebAPITestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test_GetBooks_should_return_allBooks()
        {
            BookService bookService = new BookService();

            List<Book> _bookList = new List<Book> {
            new Book { bookName = "Tide", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 },
            new Book { bookName = "Trylle", authorName = "Amanda Hocking", isbnNumber = 13445, price = 200.0 }
        };

            Assert.Equal(_bookList.ToString(), bookService.GetBooks().ToString());
        }

        [Fact]
        public void Test_GetBookByID_should_return_book()
        {
            BookService bookService = new BookService();

            Book expected = new Book { bookName = "Tide", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 };

            Assert.Equal(expected.ToString(), bookService.GetBookById(12345).ToString());
        }

        [Fact]
        public void Test_whether_book_added_to_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Wake", authorName = "Amanda Hocking", isbnNumber = 34590, price = 200.0 };
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(book),bookService.AddBook(book));
        }

        [Fact]
        public void Test_whether_book_data_updated_in_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Tide", authorName = "Amanda", isbnNumber = 12345, price = 200.0 };
            bookService.UpdateBook(12345, book);
            Assert.Equal(book.ToString(), bookService.GetBookById(12345).ToString());
        }

        [Fact]
        public void Test_whether_book_deleted_from_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Elegy", authorName = "Amanda Hocking", isbnNumber = 56709, price = 200.0 };
            var addedBook = bookService.AddBook(book);
            bookService.DeleteBook(35465);
            Assert.Null(bookService.GetBookById(35465));
        }

        [Fact]
        public void Test_when_id_is_negative_while_updating_should_return_invalid()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Elegy", authorName = "Amanda Hocking", isbnNumber = 35465, price = 200.0 };
            Assert.False(bookService.UpdateBook(-9,book));
        }

        [Fact]
        public void Test_when_id_is_negative_while_deleting_should_return_invalid()
        {
            BookService bookService = new BookService();
            Assert.False(bookService.DeleteBook(-9));
        }

        [Fact]
        public void Test_when_updating_book_not_present_should_return_false()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Wake", authorName = "Amanda Hocking", isbnNumber = 67890, price = 200.0 };
            Assert.False(bookService.UpdateBook(00000, book));
        }

        [Fact]
        public void Test_when_deleting_book_not_present_should_return_false()
        {
            BookService bookService = new BookService();
            Assert.False(bookService.DeleteBook(00000));
        }


        [Theory]
        [InlineData("ERROR!!! Enter positive value for price","Wake", "Amanda Hocking", 12345, -200.0)]
        [InlineData("ERROR!!! Enter positive ISBN Number","Wake", "Amanda Hocking", -12345, 200.0)]
        [InlineData("ERROR!!! Enter Valid Book Name","", "Amanda Hocking", 12345, 200.0)]
        [InlineData("ERROR!!! Enter Valid Author Name","Wake", "Amanda 123", 12345, 200.0)]
        [InlineData("ERROR!!! Enter Valid Author Name,ERROR!!! Enter positive ISBN Number,ERROR!!! Enter positive value for price", "Wake", "Amanda 123", -12345, -200.0)]
        public void Test_when_adding_newBook_contains_invalid_data_should_return_false(string result,string bookName, string authorName,int isbnNumber,float price)
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = bookName, authorName = authorName, isbnNumber = isbnNumber, price = price };
            Assert.Equal(result,bookService.AddBook(book));
        }

        [Fact]

        public void Test_when_user_enters_duplicate_isbnNumber_returns_error_message()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Wake", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 };
            Assert.Equal("ISBN Number taken", bookService.AddBook(book));
        }
    }
}
