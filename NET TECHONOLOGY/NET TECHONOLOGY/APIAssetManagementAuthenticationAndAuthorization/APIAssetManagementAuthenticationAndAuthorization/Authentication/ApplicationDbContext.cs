using APIAssetManagementAuthenticationAndAuthorization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAssetManagementAuthenticationAndAuthorization.Authentication
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
       public  DbSet<Book> Books { get; set; }
       public  DbSet<Hardware> Hardwares { get; set; }
       public   DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
