using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Models;
using System.Collections.Generic;

namespace AssetManagement.Controllers
{
    public class BookController : Controller
    {
        public static List<Book> BookList = new List<Book>();
        int index;
        [HttpGet]
        public ViewResult AddBook()
        {
            return View();
        }
        public ViewResult DeleteBook()
        {
            return View();
        }
        public ViewResult SearchBook()
        {
            return View();
        }
        public ViewResult UpdateBook(int id)
        {
            var update = BookList.Where(s => s.id == id).FirstOrDefault();
            return View(update);
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
           
            if (ModelState.IsValid)
            {
                BookList.Add(book);
                return RedirectToAction("Index", BookList);
            }
            else
                return View();

        }
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            if(ModelState.IsValid)
            {
                
                if(BookList.Count==0)
                {
                    return View("ListEmpty");
                }
                
               Book book = BookList.Where(x => x.id == id).FirstOrDefault();
                if (book==null)
                {
                    return View("NotFound");
                    
                }
                else
                {
                    BookList.Remove(book);
                    return RedirectToAction("Index", BookList);
                }
              
              
            }
            return View();
        }
 [HttpPost]
        public ViewResult SearchBook(int id)
        {
            
            if(ModelState.IsValid)
            {
                if (BookList.Count == 0)
                {
                    return View("ListEmpty");
                }
                Book book = BookList.Where(x => x.id == id).FirstOrDefault();
                if(book==null)
                {
                    return View("NotFound");
                }
                else
                {
                    Book bookAsset = new Book()
                    {
                        id = book.id,
                        name = book.name,
                        author = book.author,
                        edition = book.edition,
                        dateOfPublish = book.dateOfPublish

                    };
                    ViewBag.bookAsset = bookAsset;
                    return View("DisplayTheSearchForBook");
                }
                              
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBook(Book bookId)
        {
            if(ModelState.IsValid)
            {
                if (BookList.Count == 0)
                {
                    return View("ListEmpty");
                }
                index = BookList.FindIndex(s => s.id ==bookId.id);
                if (index != -1)
                {
                    BookList[index] = bookId;
                    return RedirectToAction("index", BookList);
                }
                else
                {
                    return View("NotFound");
                }
                
            }
             return View();
            
        }

        public ViewResult Index()
        {
            return View();
        }
            
        
        
    }
}