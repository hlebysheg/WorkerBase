using Microsoft.EntityFrameworkCore;

namespace WorkerBase.models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Worker> Worker { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
