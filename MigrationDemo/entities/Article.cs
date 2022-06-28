using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationDemo.entities
{
    [Table("article")]
    internal class Article
    { 
        [Key]
        public int ArticleId { set; get; }

        [StringLength(100)]
        public string Title { set; get; }
    }
}
