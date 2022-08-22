using Microsoft.EntityFrameworkCore;
using DBAssetManagementSystemAPI.Models;


namespace DBAssetManagementSystemAPI.Data
{
    public partial class DBAssetManagementContext : DbContext
    {
        public DBAssetManagementContext()
        {
        }

        public DBAssetManagementContext(DbContextOptions<DBAssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Hardware> Hardwares { get; set; }
        public virtual DbSet<SoftwareLicense> SoftwareLicenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=ITT-VINAY-NV\\SQLEXPRESS;initial catalog=DBAssetManagement; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK__Book__5E5A535FBE7D8F5A");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.Author).IsUnicode(false);

                entity.Property(e => e.BookName).IsUnicode(false);

                entity.Property(e => e.Edition).IsUnicode(false);
            });

            modelBuilder.Entity<Hardware>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK__Hardware__5E5A535FB3E4B566");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.Brand).IsUnicode(false);

                entity.Property(e => e.HardwareName).IsUnicode(false);
            });

            modelBuilder.Entity<SoftwareLicense>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK__Software__5E5A535F75C550F7");

                entity.Property(e => e.SerialNo).ValueGeneratedNever();

                entity.Property(e => e.SoftwareName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
