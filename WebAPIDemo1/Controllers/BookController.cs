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
        public ActionResult Get(int id)
        {
            var response = _bookService.GetBookById(id);
            if (response.ErrorData == null)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            var response = _bookService.AddBook(value);
            if (response.ErrorData == null)
                return Ok(response);
            return BadRequest(response);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            //var index = bookList.IndexOf(bookList.Where(n => n.ISBNNumber == id).First());
            //bookList[index] = value;

            var response = _bookService.UpdateBook(id, value);

            if (response.ErrorData == null)
                return Ok(response);
            return BadRequest(response);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //bookList.Remove(bookList.Where(n => n.ISBNNumber == id).Single());
            var response = _bookService.DeleteBook(id);
            if (response.ErrorData == null)
            {
                return Ok(response);
            }
          
            return BadRequest(response);
        }
    }
}
