using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");





            base.OnModelCreating(modelBuilder);
        }
    }
}
