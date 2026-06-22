using Microsoft.EntityFrameworkCore;
using testapirest.Data.models;

namespace testapirest.Data
{
    public class AppDbContaxt : DbContext
    {
        public AppDbContaxt(DbContextOptions<AppDbContaxt> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
