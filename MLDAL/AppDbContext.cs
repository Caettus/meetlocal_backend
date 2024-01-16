using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MLDAL.Models;
using Microsoft.EntityFrameworkCore.InMemory;

namespace MLDAL
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ConnectionString"));
        }
        
        public DbSet<gathering> Gatherings { get; set; }
        
    }
}