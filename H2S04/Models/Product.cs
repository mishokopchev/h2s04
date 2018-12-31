using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace H2S04.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Column()]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }

        public string Image { get; set; } = "default.png";

        public List<ProductCategory> ProductCategory { get; set; }

        public List<ProductAttributeValue> ProductAttributes { get; set; }

        public Product()
        {

        }
    }
}
