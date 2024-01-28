using Microsoft.EntityFrameworkCore;

namespace EpsiTech.API.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
