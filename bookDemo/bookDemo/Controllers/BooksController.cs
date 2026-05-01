using bookDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route ( "api/books" )]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();

            if(book is null) 
            {
                return NotFound(); // 404 döner
            }

            return Ok(book);
        }
    }
}
