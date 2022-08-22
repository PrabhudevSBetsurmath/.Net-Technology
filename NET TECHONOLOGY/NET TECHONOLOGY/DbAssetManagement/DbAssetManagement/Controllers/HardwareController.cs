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
    public class HardwareController : Controller
    {
        DbAssetManagementContext context = new DbAssetManagementContext();
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Hardware hardware = context.Hardwares.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(hardware);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Hardware hardware)
        {
            context.Attach(hardware);
            context.Entry(hardware).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Hardware hardware = context.Hardwares.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(hardware);
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Hardware hardware)
        {
            context.Attach(hardware);
            context.Entry(hardware).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Hardware hardware)
        {
            context.Add(hardware);
            context.Entry(hardware).State = EntityState.Added;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(int SerialNo)
        {
            if (ModelState.IsValid)
            {
                Hardware hardware = context.Hardwares.Where(x => x.SerialNo == SerialNo).FirstOrDefault();
                if (hardware == null)
                {
                    return View("NotFound");
                }
                else
                {
                    Hardware hardwareAsset = new Hardware()
                    {
                        SerialNo = hardware.SerialNo,
                        HardwareName = hardware.HardwareName,
                        Brand = hardware.Brand,
                        InstallationDate= hardware.InstallationDate,
                        Amount = hardware.Amount

                    };
                    ViewBag.hardwareAsset = hardwareAsset;
                    return View("DisplayTheSearched");

                }
            }
            return View();

        }

        public IActionResult Index()
        {
            List<Hardware> hardwares = context.Hardwares.ToList();
            return View(hardwares);
        }
        public IActionResult Details(int id)
        {
            Hardware hardware = context.Hardwares.Where(x => x.SerialNo == id).FirstOrDefault();
            return View(hardware);
        }
    }
}
