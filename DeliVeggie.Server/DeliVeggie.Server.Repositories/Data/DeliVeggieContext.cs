using DeliVeggie.Server.Repositories.Models;
using MongoDB.Driver;
using System;

namespace DeliVeggie.Server.Repositories.Data
{
    public class DeliVeggieContext : IDeliVeggieContext
    {
        public DeliVeggieContext()
        {
            //Todo: Connection settings to be moved to appsetting.json file
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggie");

            Products = database.GetCollection<ProductEntity>("Products");
            PriceReductions = database.GetCollection<PriceReductionEntity>("PriceReductions");

            DeliVeggieContextSeed.SeedData(Products);
            DeliVeggieContextSeed.SeedData(PriceReductions);
        }

        public IMongoCollection<ProductEntity> Products { get;  }
        public IMongoCollection<PriceReductionEntity> PriceReductions { get; }
    }
}
