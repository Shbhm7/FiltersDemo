using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var bookItems = await _context.Books.ToListAsync();
        return Ok(bookItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetbookItem(int id)
    {
        var bookItem = await _context.Books.FindAsync(id);
        if (bookItem == null)
        {
            return NotFound();
        }
        return Ok(bookItem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Book), new { id = book.Id }, book);
    }

 

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
        {
            return BadRequest();
        }
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var bookk = await _context.Books.FindAsync(id);
        if (bookk == null)
        {
            return NotFound();
        }
        _context.Books.Remove(bookk);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
