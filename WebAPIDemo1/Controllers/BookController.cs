using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo1.Model;
using WebAPIDemo1.Service;

namespace WebAPIDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _bookService = new BookService();

        public static List<Book> bookList = new List<Book> {
            new Book { bookName = "Tide", authorName = "Amanda Hocking", isbnNumber = 12345, price = 200.0 },
            new Book { bookName = "Trylle", authorName = "Amanda Hocking", isbnNumber = 13445, price = 200.0 }
        };


        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetBooks();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<Book> Get(int id)
        {
            return _bookService.GetBookById(id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            _bookService.AddBook(value);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            //var index = bookList.IndexOf(bookList.Where(n => n.isbnNumber == id).First());
            //bookList[index] = value;

            if (_bookService.UpdateBook(id, value))
                return Ok();
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //bookList.Remove(bookList.Where(n => n.isbnNumber == id).Single());
            _bookService.DeleteBook(id);
        }
    }
}
