using BlogApiDemo.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-S74UGVJ;database=BlogProjectApi;integrated security=true;TrustServerCertificate=True");

        }

        public DbSet<Category> Categories { get; set; }

    }
}
