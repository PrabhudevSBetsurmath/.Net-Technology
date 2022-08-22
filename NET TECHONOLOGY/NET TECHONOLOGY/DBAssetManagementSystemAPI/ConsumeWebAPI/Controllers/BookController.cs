using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;



namespace ConsumeWebAPI.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44347/api");
        HttpClient client;
        public BookController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress; //setting web api base address
        }
        public ActionResult Index()
        {
            List<BookModel> modelList = new List<BookModel>();
            HttpResponseMessage response =client.GetAsync(client.BaseAddress + "/book").Result; //getting response from webapi
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;//returns data as json string from api application
                //now data is obtained in json format now we have to deseralize it modelList
               modelList= JsonConvert.DeserializeObject<List<BookModel>>(data);
            }
            return View(modelList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookModel bookModel)
        {
            string data = JsonConvert.SerializeObject(bookModel);//these two lines represents the way to convert javascript object in json string
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json"); //her we are using stringcontent to pass it as an http content
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/book",content).Result; 
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
       
        public ActionResult Edit(int id)
        {
            //as we are made here get request in index method same we have to make get request for a single user here
            BookModel model = new BookModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/book/"+id).Result; //getting response from webapi
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;//returns data as json string from api application
                                                                         
                model = JsonConvert.DeserializeObject<BookModel>(data); //now data is obtained in json format now we have to deseralize it modelList
            }
                return View(model);
        }
        [HttpPost]
        public  ActionResult Edit(BookModel bookModel)
        {
            string data = JsonConvert.SerializeObject(bookModel);//these two lines represents the way to convert javascript object in json string
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json"); //her we are using stringcontent to pass it as an http content
            HttpResponseMessage response =  client.PutAsync(client.BaseAddress + "/book",content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(); 
        }
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/book/" + id).Result;
            
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            //BookModel model = new BookModel();
            //HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/booksearch/" +id).Result; //getting response from webapi
            //if (response.IsSuccessStatusCode)
            //{
            //    string data = response.Content.ReadAsStringAsync().Result;//returns data as json string from api application
            //                                                              //now data is obtained in json format now we have to deseralize it modelList
            //    model = JsonConvert.DeserializeObject<BookModel>(data);
            //}
            //return View(model);
            BookModel book = new BookModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/Book/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<BookModel>(results);
            }
            return View(book);

        }
    }
} 
