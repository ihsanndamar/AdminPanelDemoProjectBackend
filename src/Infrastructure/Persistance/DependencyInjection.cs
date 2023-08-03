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
                options.UseMySQL("server=localhost;database=aspnetcore;user=root;password=password;")
                );

            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}