using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL("Server=paneldb.czhqy4et8tob.eu-north-1.rds.amazonaws.com;Port=3306;Database=paneldb;Username=ihsan;Password=password!1;");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");


            base.OnModelCreating(modelBuilder);
        }
    }
}
