using APIAssetManagementAuthenticationAndAuthorization.Authentication;
using APIAssetManagementAuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace APIAssetManagementAuthenticationAndAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLicenseController : ControllerBase
    {
       
        private readonly ApplicationDbContext context;
        public SoftwareLicenseController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [Authorize(Roles = "User, Admin")]
        // GET: api/Softwares
        [HttpGet]
        public IActionResult GetSoftware()
        {
            return Ok(context.SoftwareLicenses.ToList());
        }
        [Authorize(Roles = "User, Admin")]
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
        [Authorize(Roles = "Admin")]
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
                return Ok("Deleted successfully");
            }

        }
        [Authorize(Roles = "User, Admin")]
        // POST: api/Softwares
        [HttpPost]
        public IActionResult AddSofware(string SoftwareName, DateTime DateOfExpiry, int price, DateTime DateOfPublish)
        {
            SoftwareLicense software = new SoftwareLicense
            {
               
                SoftwareName = SoftwareName,
                DateOfExpiry = DateOfExpiry,
                Price = price,
                DateOfPublish = DateOfPublish

            };

            context.SoftwareLicenses.Add(software);
            context.SaveChanges();
            return Ok("Added successfully");
        }
        [Authorize(Roles = "User, Admin")]
        // PUT: api/Books
        [HttpPut]
        public IActionResult UpdateSofware(int id, string SoftwareName, DateTime DateOfExpiry, int price, DateTime DateOfPublish)
        {
            SoftwareLicense softwareLicenseId = new SoftwareLicense();
            if (id != softwareLicenseId.SerialNo)
            {
                return BadRequest("id not found");
            }
            else
            {
                SoftwareLicense software = new SoftwareLicense
                {
                    
                    SoftwareName = SoftwareName,
                    DateOfExpiry = DateOfExpiry,
                    Price = price,
                    DateOfPublish = DateOfPublish

                };
                context.Update(software);
                context.SaveChanges();
                return CreatedAtAction("GetSofware", software);
            }

        }
        [Authorize(Roles = "Admin")]
        [Route("AssignUserToSofware")]
        [HttpPatch]
        public IActionResult AssignUserToSoftware(int serialNo, string username)
        {
            SoftwareLicense software = new SoftwareLicense();
            software = context.SoftwareLicenses.Find(serialNo);
           software.AssignedUser = username;
            context.Update(software);
            context.SaveChanges();
            return Ok("Assigned");
        }
        [Authorize(Roles = "Admin")]
        [Route("UnAssignUserToBook")]
        [HttpPatch]
        public IActionResult UnAssignUserToSoftware(int serialNo)
        {
            SoftwareLicense software = new SoftwareLicense();
            software = context.SoftwareLicenses.Find(serialNo);
            software.AssignedUser =null;
            context.Update(software);
            context.SaveChanges();   
            return Ok("UnAssigned");
        }


    }
}
