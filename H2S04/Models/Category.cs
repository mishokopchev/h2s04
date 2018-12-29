using System;
using System.Collections.Generic;

namespace H2S04.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategory { get; set; }

        public Category()
        {
        }
    }
}
