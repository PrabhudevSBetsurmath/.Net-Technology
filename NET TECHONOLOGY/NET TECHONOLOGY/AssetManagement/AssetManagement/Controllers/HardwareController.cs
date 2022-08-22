using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Models;
using System.Collections.Generic;

namespace AssetManagement.Controllers
{
    public class HardwareController : Controller
    {
        public static List<Hardware> HardwareList = new List<Hardware>();
        int index;
        [HttpGet]
        public ViewResult AddHardware()
        {
           return View();
        }
        public ViewResult DeleteHardware()
        {
            return View();
        }
        public ViewResult SearchHardware()
        {
            return View();
        }
        public ViewResult UpdateHardware(int id)
        {
            var update = HardwareList.Where(s => s.id == id).FirstOrDefault();
            return View(update);
        }
        [HttpPost]
        public ActionResult AddHardware(Hardware hardware){
                TryUpdateModelAsync(hardware);
                if(ModelState.IsValid)
                {
                    HardwareList.Add(hardware)   ;
                    
                    return RedirectToAction("Index",HardwareList);
                }
                else 
                return View();
        } 
         [HttpPost]
        public ViewResult SearchHardware(int id)
        {
            
            if (ModelState.IsValid)
            {
                if (HardwareList.Count == 0)
                {
                    return View("ListEmpty");
                }
                Hardware hardware = HardwareList.Where(x => x.id == id).FirstOrDefault();
                if (hardware == null)
                {
                    return View("NotFound");
                }
                else
                {
                    Hardware hardwareAsset = new Hardware()
                    {
                        id = hardware.id,
                        name = hardware.name,
                        brand = hardware.brand,
                        installationDate = hardware.installationDate,
                        amount = hardware.amount

                    };
                    ViewBag.hardwareAsset = hardwareAsset;
                    return View("DisplayTheSearchForHardware");
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteHardware(int id)
        {
           
            if (ModelState.IsValid)
            {
                Hardware hardware = HardwareList.Where(x => x.id == id).FirstOrDefault();
                if (hardware == null)
                {
                    return View("NotFound");

                }
                else
                {
                    HardwareList.Remove(hardware);
                    return RedirectToAction("Index", HardwareList);
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateHardware(Hardware updateid)
        {
            if (ModelState.IsValid)
            {
                if (HardwareList.Count == 0)
                {
                    return View("ListEmpty");
                }
                index = HardwareList.FindIndex(s => s.id == updateid.id);
                if (index != -1)
                {
                    HardwareList[index] = updateid;
                    return RedirectToAction("index", HardwareList);
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

        

   