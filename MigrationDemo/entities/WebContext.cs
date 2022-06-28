using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDemo.entities
{
    internal class WebContext : DbContext
    {
        public DbSet<Article> articles { set; get; }
        public DbSet<Tag> tags { set; get; }

        public const string ConnectStrring =
            @"Data Source=KHAIBQ3-D8\SQLEXPRESS;
            Initial Catalog=webdb;
            User ID=admin;
            Password=1234";

        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Debug)
                .AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectStrring);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
