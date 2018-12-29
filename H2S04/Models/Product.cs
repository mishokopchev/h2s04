using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace H2S04.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }

        public List<ProductCategory> ProductCategory { get; set; }

        public Product()
        {

        }
    }
}
