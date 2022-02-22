using expenses_project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace expenses_project.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<expense> expenses { get; set; }

    }
}
