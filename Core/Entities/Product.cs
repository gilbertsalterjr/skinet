using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(64)]
        public string ISBN { get; set; }
        [Column(TypeName = "decimal(10,2")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [StringLength(64)]
        public string Author { get; set; }
        [StringLength(50)]
        public string ImageName { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }
    }
}