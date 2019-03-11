using System.Linq;
using IntegrationTestsSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestsSample.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpGet("{isbn}")]
        public IActionResult Get(string isbn)
        {
            if (!IsIsbnValid(isbn))
            {
                return BadRequest();
            }

            var book = GetBookByIsbn(isbn);
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        private bool IsIsbnValid(string isbn)
        {
            return isbn?.Length == 13;
        }

        private Book GetBookByIsbn(string isbn)
        {
            var book = _context.Books.FirstOrDefault(x => x.Isbn == isbn);
            return book;
        }
    }
}
