using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo.entities
{
    internal class ShopContext : DbContext
    {
        // Logging
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        public DbSet<Product> products { set; get; }
        public DbSet<Category> categories { set; get; }

        private readonly String connectionString = @"
            Data Source=KHAIBQ3-D8\SQLEXPRESS;
            Initial Catalog=shop;
            User ID=admin;
            Password=1234;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<Product>(entity =>
            {
                // Table mapping
                entity.ToTable("products");
                // PK
                entity.HasKey(p => p.ProductId);
                // Index
                entity.HasIndex(p => p.Price).HasDatabaseName("index-sanpham");
                // Relative
                entity.HasOne(p => p.Category)
                      .WithMany()
                      .HasForeignKey("FK-products")
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
