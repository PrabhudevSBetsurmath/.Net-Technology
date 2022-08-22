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
    public class RequestingAssetController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public RequestingAssetController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [Authorize(Roles = "User")]
        [Route("RequestAsset")]
        [HttpPost]
        public IActionResult RequestAsset(int AssetId, string AssetName, string UserName)
        {
            RequestAssetModel requestAsset = new RequestAssetModel
            {
                AssetId = AssetId,
                AssetName = AssetName,
                UserName = UserName
            };

            context.RequestAsset.Add(requestAsset);
            context.SaveChanges();
            return Ok("Added successfully");
        }

        [Authorize(Roles = "Admin")]
        [Route("GetRequestAsset")]
        [HttpGet]
        public IActionResult GetRequestAsset()
        {
            return Ok(context.RequestAsset.ToList());
        }
    }
}
