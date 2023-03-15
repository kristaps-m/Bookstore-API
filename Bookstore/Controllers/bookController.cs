using Bookstore.Core.Models;
using Bookstore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class bookController : ControllerBase
    {
        private readonly IBookStorage _bookStorage;

        public bookController(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }

        [Authorize]
        [Route("add")]
        [HttpPut]
        public IActionResult PutReceipt(Book book)
        {
            var addedBook = _bookStorage.AddBook(book);
            if (addedBook == null)
            {
                return BadRequest($"Book with Title: {book.Title} already exists!");
            }

            return Created($"{book.Title} created", book);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBook(int id)
        {
            var book = _bookStorage.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // https://localhost:7025/book/?start=0&take=3
        //[Route("")]
        [HttpGet]
        public IActionResult GetAllBooks(int start, int take)
        {            
            var fewBooks = _bookStorage.GetAllBooks().Skip(start).Take(take);

            return Ok(fewBooks);
        }
    }
}
