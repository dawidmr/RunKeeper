using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RunKeeper.Model;

namespace RunKeeper.DataScaffolded
{
    public class RunKeeperContext : DbContext
    {
        public RunKeeperContext (DbContextOptions<RunKeeperContext> options)
            : base(options)
        {
        }

        public DbSet<RunKeeper.Model.DataEx> DataEx { get; set; }
    }
}
