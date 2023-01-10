using Microsoft.EntityFrameworkCore;
using PlutoTool.Models;
using System.Security.Principal;

namespace PlutoTool.Database
{
    public class PlutoDbContext : DbContext
    {
        public PlutoDbContext(DbContextOptions<PlutoDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Payee> Payee { get; set; } = null!;
        public DbSet<WorkOrder> WorkOrder { get; set; } = null!;
        public DbSet<Vehicle> Vehicle { get; set; } = null!;

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>()
            //    .HasF(p => p.OwnerUser).WithRequired(p => p.Instructor);
        }
    }
}
