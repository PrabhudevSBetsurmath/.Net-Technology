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
    public class SoftwareLicenseController : Controller
    {
        DbAssetManagementContext context = new DbAssetManagementContext();
        [HttpGet]
        public IActionResult Edit(int id)
        {
            SoftwareLicense software = context.SoftwareLicenses.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(software);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Edit(SoftwareLicense software)
        {
            context.Attach(software);
            context.Entry(software).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            SoftwareLicense software = context.SoftwareLicenses.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(software);
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(SoftwareLicense software)
        {
            context.Attach(software);
            context.Entry(software).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(SoftwareLicense software)
        {
            context.Add(software);
            context.Entry(software).State = EntityState.Added;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(int SerialNo)
        {
            if (ModelState.IsValid)
            {
                SoftwareLicense software = context.SoftwareLicenses.Where(x => x.SerialNo == SerialNo).FirstOrDefault();
                if (software == null)
                {
                    return View("NotFound");
                }
                else
                {
                    SoftwareLicense softwareAsset = new SoftwareLicense()
                    {
                        SerialNo = software.SerialNo,
                        SoftwareName = software.SoftwareName,
                        DateOfPublish = software.DateOfPublish,
                        DateOfExpiry = software.DateOfExpiry,
                        Price = software.Price
                        

                    };
                    ViewBag.softwareAsset = softwareAsset;
                    return View("DisplayTheSearched");

                }
            }
            return View();

        }

        public IActionResult Index()
        {
            List<SoftwareLicense> softwareLicenses = context.SoftwareLicenses.ToList();
            return View(softwareLicenses);
        }
        public IActionResult Details(int id)
        {
            SoftwareLicense softwareLicenses = context.SoftwareLicenses.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(softwareLicenses);
        }
    }
}
