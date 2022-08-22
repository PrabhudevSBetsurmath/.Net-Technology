using DBAssetManagementSystemAPI.Data;
using DBAssetManagementSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAssetManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DBAssetManagementContext _context;
        public BookController(DBAssetManagementContext context)
        {
            _context = context;

        }
       
        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_context.Books.ToList());
        }
        // GET: api/Books/ID
        [HttpGet("{id}")]
        public IActionResult SearchBook(int id)
        {
            Book book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }

        }
        // POST: api/Books
        [HttpPost]
        public IActionResult AddBook(Book book)
        {

            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok();
        }
        // PUT: api/Books
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            if (_context.Books.Any(e => e.SerialNo == book.SerialNo))
            {
                _context.Update(book);
                _context.SaveChanges();
                return CreatedAtAction("GetBooks", book);

            }
            return BadRequest();



        }
    }
}
