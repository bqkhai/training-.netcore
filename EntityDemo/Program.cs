using EntityDemo.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityDemo
{
    internal class Program
    {
        /**
         * Create database
         */
        static void Createdatabase()
        {
            using var dbContext = new ProductDbContext();
            string dbname = dbContext.Database.GetDbConnection().Database;

            var res = dbContext.Database.EnsureCreated();
            if (res)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

        /**
         * Delete database
         */
        //static void Deletedatabase()
        //{
        //    var dbContext = new ProductDbContext();
        //    dbContext.Database.EnsureDeleted();
        //}

        static void InsertProduct()
        {
            using var dbcontext = new ProductDbContext();

            var p1 = new Product()
            {
                Name = "San pham2",
                Price = 12,
            };

            dbcontext.Add(p1);
            dbcontext.SaveChanges();
        }

        static void ReadProducts()
        {
            using var dbcontext = new ProductDbContext();

            //var products = dbcontext.products.ToList();
            //products.ForEach(product => product.PrintInfo());

            //linq
            var qr = from product in dbcontext.products
                     where product.ProductId <= 3
                     select product;

            qr.ToList().ForEach(product => product.PrintInfo());
        }

        // Delete
        static void DeleteProduct()
        {
            var dbcontext = new ProductDbContext();
        }

        // Update
        static void RenameProduct(int id, string newName)
        {
            var dbcontext = new ProductDbContext();
            var product = (from p in dbcontext.products 
                           where (p.ProductId == id) 
                           select p)
                           .FirstOrDefault();

            // Đổi tên và cập nhật
            if (product != null)
            {
                product.Name = newName;
                Console.WriteLine($"{product.ProductId,2} có tên mới = {product.Name,10}");
                dbcontext.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            Createdatabase();
            //InsertProduct();
            //ReadProducts();
            //RenameProduct(1,"abc");
        }
    }
}
