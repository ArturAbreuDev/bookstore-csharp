using apibookstore.entities.models;
using Microsoft.AspNetCore.Mvc;

namespace apibookstore.controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

    public BooksControllers(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return Ok(await _bookRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        await _bookRepository.AddAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        await _bookRepository.UpdateAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookRepository.DeleteAsync(id);
        return NoContent();
    }
    }
}