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
            new Book { Name = "Tide", AuthorName = "Amanda Hocking", ISBNNumber = 12345, Price = 200.0 },
            new Book { Name = "Trylle", AuthorName = "Amanda Hocking", ISBNNumber = 13445, Price = 200.0 }
        };


        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetBooks();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound("ERROR!!! Book Not Found");
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            var response = _bookService.AddBook(value);
            if (response.ErrorData == null)
                return Ok(response);
            return NotFound(response);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            //var index = bookList.IndexOf(bookList.Where(n => n.ISBNNumber == id).First());
            //bookList[index] = value;

            if (_bookService.UpdateBook(id, value))
                return Ok(_bookService.GetBookById(id));
            return NotFound("ERROR!!! ID must be Positive or Book Not Found");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //bookList.Remove(bookList.Where(n => n.ISBNNumber == id).Single());
            if(_bookService.DeleteBook(id))
            {
                return Ok();
            }
            return NotFound("ERROR!!! ID must be Positive or Book Not Found");
        }
    }
}
