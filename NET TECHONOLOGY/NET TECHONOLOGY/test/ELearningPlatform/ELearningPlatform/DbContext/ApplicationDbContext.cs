using ELearningPlatform.Models;
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
        public DbSet<CalenderModel> CalenderEvents { get; set; }
        public DbSet<ChatModel> Chat { get; set; }
        public DbSet<FileModel> Files { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
        .Entity<FileModel>()
        .Property(e => e.FileType)
        .HasConversion(
            v => v.ToString(),
            v => (EnumModel)Enum.Parse(typeof(EnumModel), v));
        }
    }
}
