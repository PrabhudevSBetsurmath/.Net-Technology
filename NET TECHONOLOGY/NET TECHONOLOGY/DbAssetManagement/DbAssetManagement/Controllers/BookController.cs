using DbAssetManagement.Data;
using DbAssetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAssetManagement.Controllers
{
    public class BookController : Controller
    {
        DbAssetManagementContext context = new DbAssetManagementContext();
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = context.Books.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(book);
        }
       
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            context.Attach(book);
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book book = context.Books.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(book);
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            context.Attach(book);
            context.Entry(book).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            context.Attach(book);
            context.Entry(book).State = EntityState.Added;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(int SerialNo)
        {
           
            if(ModelState.IsValid)
            {
                Book book = context.Books.Where(x => x.SerialNo == SerialNo).FirstOrDefault();
                if (book == null)
                {
                    return View("NotFound");
                }
                else
                {
                    Book bookAsset = new Book()
                    {
                        SerialNo = book.SerialNo,
                        BookName = book.BookName,
                        Author = book.Author,
                        Edition = book.Edition,
                        DateOfPublish = book.DateOfPublish

                    };
                    ViewBag.bookAsset = bookAsset;
                    return View("DisplayTheSearched");

                }
            }
            return View();

        }

        public IActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            Book book = context.Books.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(book);
        }
    }
}
