using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
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
               services.AddTransient<IUserRepository,UserRepository>();
               services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
               services.AddDbContext<DataContext>(options =>
               {
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"));//sql lite connection strings
               });

               return services;
          }
     }
}