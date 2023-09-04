using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");


            base.OnModelCreating(modelBuilder);
        }
    }
}
