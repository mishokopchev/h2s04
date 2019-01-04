using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H2S04.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public bool Verified { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        public bool Comment { get; set; }
        public string OwnerID { get; set; }

        public Order()
        {
        }
    }
}
