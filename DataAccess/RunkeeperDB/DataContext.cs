using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.RunkeeperDB
{
    public class DataContext: DbContext
    {
        public DbSet<Data> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connString = @"Data Source=daw.database.windows.net;Initial Catalog=Runkeeper;User ID=dawid;Password=At@kujaAZ8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            options.UseSqlServer(connString);
        }
    }
}
