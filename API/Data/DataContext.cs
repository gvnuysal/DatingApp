using API.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Data
{
     public class DataContext : DbContext
     {
          public DataContext(DbContextOptions options) : base(options)
          {

          }


          public DbSet<AppUser> Users { get; set; }

     }
}