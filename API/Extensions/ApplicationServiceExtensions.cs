using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
     public static class ApplicationServiceExtensions
     {
          public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
          {
               services.AddTransient<ITokenService, TokenService>();
               services.AddDbContext<DataContext>(options =>
               {
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"));//sql lite connection strings
               });

               return services;
          }
     }
}