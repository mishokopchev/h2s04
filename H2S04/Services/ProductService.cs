using System;
using System.Collections.Generic;
using H2S04.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace H2S04.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Bag> _collection;

        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("AlcoholStoreDb"));
            var database = client.GetDatabase("AlcoholDb");
            _collection = database.GetCollection<Bag>("Products");

        }

        public Bag Get(string id)
        {
            var bag = _collection.Find<Bag>(b => b.UserId == id).FirstOrDefault();
            return bag;
        }

        public List<Bag> All()
        {
            return _collection.Find(b => true).ToList();
        }

        public void Insert(Bag bag)
        {
            _collection.InsertOne(bag);
        }

        public void Update(Bag newOne)
        {
            _collection.ReplaceOne(bag => bag.Id == newOne.Id,newOne);
        }


    }
}
