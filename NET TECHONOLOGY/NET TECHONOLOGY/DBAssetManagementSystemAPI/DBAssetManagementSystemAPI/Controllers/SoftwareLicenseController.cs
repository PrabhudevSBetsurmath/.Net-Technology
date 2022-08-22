using DBAssetManagementSystemAPI.Data;
using DBAssetManagementSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DBAssetManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLicenseController : ControllerBase
    {
        DBAssetManagementContext context = new DBAssetManagementContext();
        // GET: api/Softwares
        [HttpGet]
        public IActionResult GetSoftware()
        {
            return Ok(context.SoftwareLicenses.ToList());
        }
        // GET: api/Softwares/ID
        [HttpGet("{id}")]
        public IActionResult SearchSoftware(int id)
        {
            SoftwareLicense software = context.SoftwareLicenses.Find(id);

            if (software == null)
            {
                return NotFound();
            }

            return Ok(software);
        }
        // DELETE: api/Softwares/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSoftware(int id)
        {
            SoftwareLicense software = context.SoftwareLicenses.Find(id);
            if (software == null)
            {
                return NotFound();
            }
            else
            {
                context.SoftwareLicenses.Remove(software);
                context.SaveChanges();
                return Ok();
            }

        }
        // POST: api/Softwares
        [HttpPost]
        public IActionResult AddSoftware(SoftwareLicense software)
        {
            context.SoftwareLicenses.Add(software);
            context.SaveChanges();
            return Ok();
        }
        // PUT: api/Softwares/5
        [HttpPut]
        public IActionResult UpdateSoftware(SoftwareLicense software)
        {
            if(context.SoftwareLicenses.Any(e=>e.SerialNo==software.SerialNo))
            {
                context.Update(software);
                context.SaveChanges();
                return CreatedAtAction("GetSoftware", software);
               
            }
            return BadRequest();


        }


    }
}
