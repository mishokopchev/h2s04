using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;

namespace H2S04.Models
{
    public class Bag
    {
        public ObjectId Id { get; set; }

        public string UserId { get; set; }

        public IList<int> Products { get; set; } = new List<int>();

    }
}
