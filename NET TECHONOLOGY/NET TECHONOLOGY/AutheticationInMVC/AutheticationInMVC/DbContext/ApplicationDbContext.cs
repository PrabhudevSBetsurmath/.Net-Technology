using AutheticationInMVC.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;


namespace ELearningPlatform.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
    .Entity<Register>(builder =>
    {
        builder.HasNoKey();
        builder.ToTable("MY_ENTITY");
    });
            base.OnModelCreating(builder);
         
        }
       
       

        //public DbSet<AutheticationInMVC.Authentication.Register>? Register { get; set; }
    }
}
