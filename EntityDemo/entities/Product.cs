using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDemo.entities
{
    [Table("products")]
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { set; get; }

        // Tao Foreign key
        public Category Category { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{ProductId,2} {Name,10} - {Price}");
        }
    }
}
