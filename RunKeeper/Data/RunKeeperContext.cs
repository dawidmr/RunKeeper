using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace RunKeeper.DataScaffolded
{
    public class RunKeeperContext : DbContext
    {
        public RunKeeperContext (DbContextOptions<RunKeeperContext> options)
            : base(options)
        {
        }

        public DbSet<DataEx> DataEx { get; set; }
    }
}
