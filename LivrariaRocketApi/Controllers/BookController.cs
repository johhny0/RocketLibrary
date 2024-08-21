using LivrariaRocketApi.Models;
using LivrariaRocketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaRocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService = new();
        
        [HttpGet]
        [ProducesResponseType<List<Book>>(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var books = _bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<Book>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType<Book>(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] BookRequest value)
        {
            var book = _bookService.Create(value);

            return Created(string.Empty, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType<Book>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] BookRequest value)
        {
            try
            {
                var book = _bookService.Update(id, value);

                if (book is null)
                    return NotFound();

                return Ok(book);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Remove(id);

            return result ? NoContent() : NotFound();
        }
    }
}
