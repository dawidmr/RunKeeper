using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler
{
    public class JsonContext : DbContext
    {
        public DbSet<Json> Json { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connString = @"Data Source=daw.database.windows.net;Initial Catalog=Runkeeper;User ID=dawid;Password=At@kujaAZ8;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            options.UseSqlServer(connString);
        }
    }

    public class Json
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
