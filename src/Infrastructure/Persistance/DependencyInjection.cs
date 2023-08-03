using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;


namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL("Server=127.0.0.1;Port=3306;Database=paneldb;User=root;Password=admin;SslMode=Required;")
                );

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}