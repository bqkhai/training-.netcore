using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required (ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayFormat(DataFormatString ="{0:MMM-dd-yy}")]
        public DateTime Dob { get; set; }

        [Required (ErrorMessage = "This field is required")]
        public string Class { get; set; }
    }
}
