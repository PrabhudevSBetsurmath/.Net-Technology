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
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
       
        private readonly ApplicationDbContext context;
        public HardwareController(ApplicationDbContext _context)
        {
            context = _context;
        }
        // GET: api/Hardwares
        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult GetHardware()
        {
            return Ok(context.Hardwares.ToList());
        }
        // GET: api/Hardwares/ID
        [Authorize(Roles = "User, Admin")]
        [HttpGet("{id}")]
        public IActionResult SearchHardware(int id)
        {
            Hardware hardware = context.Hardwares.Find(id);

            if (hardware == null)
            {
                return NotFound();
            }

            return Ok(hardware);
        }
        // DELETE: api/Hardwares/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletetHardware(int id)
        {
            Hardware hardware = context.Hardwares.Find(id);
            if (hardware == null)
            {
                return NotFound();
            }
            else
            {
                context.Hardwares.Remove(hardware);
                context.SaveChanges();
                return Ok("Deleted successfully");
            }

        }
        [Authorize(Roles = "User, Admin")]
        // POST: api/Hardwares
        [HttpPost]
        public IActionResult AddHardware(string HardwareName,string Brand,int Amount, DateTime InstallationDate)
        {
            Hardware hardware = new Hardware
            {
                
                HardwareName = HardwareName,
                Amount = Amount,
                Brand = Brand,
                InstallationDate = InstallationDate

            };

            context.Hardwares.Add(hardware);
            context.SaveChanges();
            return Ok("Added successfully");
        }
        [Authorize(Roles = "User, Admin")]
        // PUT: api/Books
        [HttpPut]
        public IActionResult UpdateHardware(int id, string HardwareName,string Brand,int Amount, DateTime InstallationDate)
        {
            Hardware hardwareId = new Hardware();
            if (id != hardwareId.SerialNo)
            {
                return BadRequest("id not found");
            }
            else
            {
                Hardware hardware = new Hardware
                {
                  
                    HardwareName = HardwareName,
                    Amount = Amount,
                    Brand=Brand,
                    InstallationDate = InstallationDate

                };
                context.Update(hardware);
                context.SaveChanges();
                return CreatedAtAction("GetHardware", hardware);
            }

        }
        [Authorize(Roles = "Admin")]
        [Route("AssignUserToHardware")]
        [HttpPatch]
        public IActionResult AssignUserToHardware(int serialNo, string username)
        {
            Hardware hardware = new Hardware();
            hardware = context.Hardwares.Find(serialNo);
            hardware.AssignedUser = username;
            context.Update(hardware);
            context.SaveChanges();
            return Ok("Assigned");
        }
        [Authorize(Roles = "Admin")]
        [Route("UnAssignUserToHardware")]
        [HttpPatch]
        public IActionResult UnAssignUserToHardware(int serialNo)
        {
            Hardware hardware = new Hardware();
            hardware = context.Hardwares.Find(serialNo);
            hardware.AssignedUser = null;
            context.Update(hardware);
            context.SaveChanges();
            return Ok("UnAssigned");
        }
    }
}
