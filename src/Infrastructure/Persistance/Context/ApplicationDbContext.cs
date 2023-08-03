using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL("server=localhost;database=database;user=user;password=password");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");





            base.OnModelCreating(modelBuilder);
        }
    }
}
