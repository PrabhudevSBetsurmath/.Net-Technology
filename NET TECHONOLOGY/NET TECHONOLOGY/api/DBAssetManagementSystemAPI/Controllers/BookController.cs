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
        DBAssetManagementContext context = new DBAssetManagementContext();
        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(context.Books.ToList());
        }
        // GET: api/Books/ID
        [HttpGet("{id}")]
        public IActionResult SearchBook(int id)
        {
            Book book =  context.Books.Find(id);

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
            Book book = context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                context.Books.Remove(book);
                context.SaveChanges();
                return Ok();
            }

        }
        // POST: api/Books
        [HttpPost]
        public IActionResult AddBook( Book book)
        {
            
            context.Books.Add(book);
            context.SaveChanges();
            return Ok();
        }
        // PUT: api/Books/5
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            if (context.Books.Any(e => e.SerialNo == book.SerialNo))
            {
                context.Update(book);
                context.SaveChanges();
                return CreatedAtAction("GetBooks", book);
                
            }
            return BadRequest();


        }
        

    }
}
