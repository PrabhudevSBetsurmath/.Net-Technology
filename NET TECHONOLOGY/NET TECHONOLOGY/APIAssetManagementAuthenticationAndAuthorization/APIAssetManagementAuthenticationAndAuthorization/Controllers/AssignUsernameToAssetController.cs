using APIAssetManagementAuthenticationAndAuthorization.Authentication;
using APIAssetManagementAuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAssetManagementAuthenticationAndAuthorization.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignUsernameToAssetController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public AssignUsernameToAssetController(ApplicationDbContext _context)
        {
            context = _context;
        }

        
        [Route("AssignUserToBook")]
        [HttpPatch]
        public IActionResult AssignUserToBook(int serialNo, string username)
        {

                Book book = new Book();
                if (serialNo == book.SerialNo && username != null)
                {
                    book = context.Books.Find(serialNo);
                    book.AssignedUser = username;
                    context.Update(book);
                    context.SaveChanges();
                    return Ok("Assigned");
                }
                return BadRequest("enter correctly all the fields");        
        }



       
        [Route("UnAssignUserToBook")]
        [HttpPatch]
        public IActionResult UnAssignUserToBook(int serialNo)
        {
            Book book = new Book();
            if(serialNo==book.SerialNo)
            {
                book = context.Books.Find(serialNo);
                book.AssignedUser = null;
                context.Update(book);
                context.SaveChanges();
                return Ok("UnAssigned");

            }
            return BadRequest("enter correct serial number");
            
        }

       
        [Route("AssignUserToHardware")]
        [HttpPatch]
        public IActionResult AssignUserToHardware(int serialNo, string username)
        {
            Hardware hardware = new Hardware();
            if (serialNo == hardware.SerialNo && username != null)
            {
                hardware = context.Hardwares.Find(serialNo);
                hardware.AssignedUser = username;
                context.Update(hardware);
                context.SaveChanges();
                return Ok("Assigned");
            }
            return BadRequest("enter correctly all the fields");
        }
      



        [Route("UnAssignUserToHardware")]
        [HttpPatch]
        public IActionResult UnAssignUserToHardware(int serialNo)
        {
            Hardware hardware = new Hardware();
            if (serialNo == hardware.SerialNo)
            {
                hardware = context.Hardwares.Find(serialNo);
                hardware.AssignedUser = null;
                context.Update(hardware);
                context.SaveChanges();
                return Ok("UnAssigned");

            }
            return BadRequest("enter correct serial number");

        }

       
        [Route("AssignUserToSofware")]
        [HttpPatch]
        public IActionResult AssignUserToSoftware(int serialNo, string username)
        {
            SoftwareLicense software = new SoftwareLicense();
            if (serialNo == software.SerialNo && username != null)
            {
                software = context.SoftwareLicenses.Find(serialNo);
                software.AssignedUser = username;
                context.Update(software);
                context.SaveChanges();
                return Ok("Assigned");
            }
            return BadRequest("enter correctly all the fields");

        }


      
        [Route("UnAssignUserToSoftware")]
        [HttpPatch]
        public IActionResult UnAssignUserToSoftware(int serialNo)
        {
            SoftwareLicense software = new SoftwareLicense();
            if (serialNo == software.SerialNo)
            {
                software = context.SoftwareLicenses.Find(serialNo);
                software.AssignedUser = null;
                context.Update(software);
                context.SaveChanges();
                return Ok("UnAssigned");
            }
            return BadRequest("enter correct serial number");

        }

    }
}
