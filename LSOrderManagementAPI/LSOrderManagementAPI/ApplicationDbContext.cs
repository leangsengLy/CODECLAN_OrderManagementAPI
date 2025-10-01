using LSOrderManagementAPI.Controllers;
using LSOrderManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LSOrderManagementAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LSITEM> LSITEMs { get; set; }
        public DbSet<LSCUSTOMER> LSCUSTOMERs { get; set; }
        public DbSet<LSORDER> LSORDERs { get; set; }
        public DbSet<LSORDER_ITEM> LSORDER_ITEMs { get; set; }
        public DbSet<LSLOGIN> LSLOGINs { get; set; }
        public DbSet<OrderQueryDto> OrderQueryDtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LSCUSTOMER>().ToTable("LSCUSTOMER");
            modelBuilder.Entity<LSITEM>().ToTable("LSITEM");
            modelBuilder.Entity<LSORDER>().ToTable("LSORDER");
            modelBuilder.Entity<LSLOGIN>().ToTable("LSLOGIN");
            modelBuilder.Entity<LSORDER_ITEM>().ToTable("LSORDER_ITEM");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderQueryDto>().HasNoKey();
        }
    }
}
