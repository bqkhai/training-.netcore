using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationDemo.entities
{
    internal class Tag
    {
        [Key]
        [StringLength(20)]
        public string TagId { set; get; }

        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}
