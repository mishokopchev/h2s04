using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H2S04.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column()]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; } = DateTime.Now;

        public List<ProductCategory> ProductCategory { get; set; }

        public Category()
        {
        }
    }
}
