using System;
using System.Collections.Generic;
using WebAPIDemo1.Model;
using Xunit;

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
            Book book = new Book { bookName = "Wake", authorName = "Amanda Hocking", isbnNumber = 67890, price = 200.0 };
            bookService.AddBook(book);
            Assert.Equal(book.ToString(), bookService.GetBookById(67890).ToString());
        }

        [Fact]
        public void Test_whether_book_data_updated_in_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Wake", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 };
            bookService.UpdateBook(12345,book);
            Assert.Equal(book.ToString(), bookService.GetBookById(12345).ToString());
        }

        [Fact]
        public void Test_whether_book_deleted_from_database()
        {
            BookService bookService = new BookService();
            Book book = new Book { bookName = "Elegy", authorName = "Amanda Hocking", isbnNumber = 35465, price = 200.0 };
            bookService.AddBook(book);
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
    }
}
