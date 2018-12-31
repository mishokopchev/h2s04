using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H2S04.Models
{
    public class AttributeValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        public Attribute Attribute { get; set; }

        public List<ProductAttributeValue> ProductAttributes { get; set; }

        public AttributeValue()
        {
        }
    }
}
