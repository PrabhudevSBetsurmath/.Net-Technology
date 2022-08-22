using DBAssetManagementSystemAPI.Data;
using DBAssetManagementSystemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAssetManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        DBAssetManagementContext context = new DBAssetManagementContext();
        // GET: api/Hardwares
        [HttpGet]
        public IActionResult GetHardware()
        {
            return Ok(context.Hardwares.ToList());
        }
        // GET: api/Hardwares/ID
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
                return Ok();
            }

        }
        // POST: api/Hardwares
        [HttpPost]
        public IActionResult AddHardware(Hardware hardware)
        {
            context.Hardwares.Add(hardware);
            context.SaveChanges();
            return Ok();
        }
        // PUT: api/Hardwares/5
        [HttpPut]
        public IActionResult UpdateHardware(Hardware hardware)
        {
            if (context.Hardwares.Any(e => e.SerialNo == hardware.SerialNo))
            {
                context.Update(hardware);
                context.SaveChanges();
                return CreatedAtAction("GetHardware", hardware);

            }
            return BadRequest();


        }
    }
}
