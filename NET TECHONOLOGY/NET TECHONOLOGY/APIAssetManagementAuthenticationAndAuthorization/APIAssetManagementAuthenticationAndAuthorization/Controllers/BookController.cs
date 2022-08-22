using APIAssetManagementAuthenticationAndAuthorization.Authentication;
using APIAssetManagementAuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAssetManagementAuthenticationAndAuthorization.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
      
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: api/Books
        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(context.Books.ToList());
        }
        // GET: api/Books/ID
        [Authorize(Roles = "User, Admin")]
        [HttpGet("{id}")]
        public IActionResult SearchBook(int id)
        {
            Book book = context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [Authorize(Roles = "Admin")]
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
                return Ok("Deleted successfully");
            }

        }
        [Authorize(Roles = "User, Admin")]
        // POST: api/Books
        [HttpPost]
        public IActionResult AddBook( string BookName, string Author,string Edition,DateTime DateOfPublish)
        {
            Book book = new Book
            {
             
                BookName=  BookName,
                Author=Author,
                Edition=Edition,
                DateOfPublish=DateOfPublish,
                
            };

            context.Books.Add(book);
            context.SaveChanges();
            return Ok("Added successfully");
        }
        [Authorize(Roles = "User, Admin")]
        // PUT: api/Books
        [HttpPut]
        public IActionResult UpdateBook(int id, string BookName, string Author, string Edition, DateTime DateOfPublish)
        {
            Book bookId = new Book();
            if(id!=bookId.SerialNo)
            {
                return BadRequest("id not found");
            }
            else
            {
                Book book = new Book
                {
                   
                    BookName = BookName,
                    Author = Author,
                    Edition = Edition,
                    DateOfPublish = DateOfPublish,

                };
                     context.Books.Update(book);
                     context.SaveChanges();
                     return CreatedAtAction("GetBooks", book);
            }
           
        }
        [Authorize(Roles = "Admin")]
        [Route("AssignUserToBook")]
        [HttpPatch]
        public IActionResult AssignUserToBook(int serialNo,string username)
        {
            Book book = new Book();
            book=context.Books.Find(serialNo);
            book.AssignedUser = username;
            context.Update(book);
            context.SaveChanges();
            return Ok("Assigned");
        }
        [Authorize(Roles = "Admin")]
        [Route("UnAssignUserToBook")]
        [HttpPatch]
        public IActionResult UnAssignUserToBook(int serialNo)
        {
            Book book = new Book();
            book = context.Books.Find(serialNo);
            book.AssignedUser =null;
            context.Update(book);
            context.SaveChanges();
            return Ok("UnAssigned");
        }
    }
}
