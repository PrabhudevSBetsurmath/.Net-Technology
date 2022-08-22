using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class SoftwareController : Controller
    {
        public static List<Software> SoftwareList = new List<Software>();
        int index;
        [HttpGet]
        public ViewResult AddSoftware()
        {
           return View();
        }
         public ViewResult DeleteSoftware()
        {
            return View();
        }
           public ViewResult SearchSoftware()
        {
            return View();
        }
           public ViewResult UpdateSoftware(int id)
        {
            var update = SoftwareList.Where(s => s.id == id).FirstOrDefault();
            return View(update);
        }

        [HttpPost]
        public ActionResult AddSoftware(Software software){
                
                if(ModelState.IsValid)
                {
                SoftwareList.Add(software);
                return RedirectToAction("Index",SoftwareList);
                }
                else 
                return View();

        }

        [HttpPost]
        public ViewResult SearchSoftware(int id)
        {

            if (ModelState.IsValid)
            {
                if (SoftwareList.Count == 0)
                {
                    return View("ListEmpty");
                }
                Software software = SoftwareList.Where(x => x.id == id).FirstOrDefault();
                if (software == null)
                {
                    return View("NotFound");
                }
                else
                {
                    Software sofwareAsset = new Software()
                    {
                        id = software.id,
                        name = software.name,
                        dateOfPublish = software.dateOfPublish,
                        dateOfExpiry = software.dateOfExpiry,
                        price = software.price

                    };
                    ViewBag.softwareAsset = sofwareAsset;
                    return View("DisplayTheSearchForSoftware");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSoftware(int id)
        {
           
            if(ModelState.IsValid)
                {
                Software software = SoftwareList.Where(x => x.id == id).FirstOrDefault();
                if (software == null)
                {
                    return View("NotFound");

                }
                else
                {
                    SoftwareList.Remove(software);
                    return RedirectToAction("Index", SoftwareList);
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSoftware(Software updateid)
        {
            if (ModelState.IsValid)
            {
                if (SoftwareList.Count == 0)
                {
                    return View("ListEmpty");
                }
                index = SoftwareList.FindIndex(s => s.id == updateid.id);
                if (index != -1)
                {
                    SoftwareList[index] = updateid;
                    return RedirectToAction("index", SoftwareList);
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