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
            optionsBuilder.UseMySQL("Server=test.czhqy4et8tob.eu-north-1.rds.amazonaws.com;Port=3306;Username=test;Password=1029384756;Database=paneldb;");
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");


            base.OnModelCreating(modelBuilder);
        }
    }
}
