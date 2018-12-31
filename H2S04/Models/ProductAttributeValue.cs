using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H2S04.Models
{
    public class ProductAttributeValue
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int AttributeValueId { get; set; }

        public Product Product { get; set; }
        public AttributeValue AttributeValue { get; set; }

        public ProductAttributeValue()
        {
        }
    }
}
