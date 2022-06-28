using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }

        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID} {Name,1} {Price,1} {Brand,1} {string.Join(",", Colors)}";

    }

    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    450, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    450, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };


            // price = 400
            var query = from product in products
                         where product.Price == 400
                         select product;

            foreach (var product in query)
                Console.WriteLine(product.ToString());

            // Lấy ra 
            var query2 = brands.GroupJoin(products, b => b.ID, p => p.Brand, (b, p) =>
            {
                return new
                {
                    thuonghieu = b.Name,
                    sanpham = p
                };
            });

            foreach(var gr in query2)
            {
                Console.WriteLine(gr.thuonghieu);
                foreach(var p in gr.sanpham)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}
