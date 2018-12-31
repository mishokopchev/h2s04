using System;
namespace H2S04.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Scale { get; set; }


        public Review()
        {
        }
    }
}
