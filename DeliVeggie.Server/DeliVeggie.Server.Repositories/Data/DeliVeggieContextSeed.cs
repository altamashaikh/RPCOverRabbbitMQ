using DeliVeggie.Server.Repositories.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliVeggie.Server.Repositories.Data
{
    public class DeliVeggieContextSeed
    {
        public static void SeedData(IMongoCollection<ProductEntity> products)
        {
            var existsProduct = products.Find(p => true).Any();

            if (!existsProduct)
            {
                products.InsertManyAsync(GetProductEntities());
            }
        }

        public static void SeedData(IMongoCollection<PriceReductionEntity> priceReductions)
        {
            var existsPriceReduction = priceReductions.Find(p => true).Any();

            if (!existsPriceReduction)
            {
                priceReductions.InsertManyAsync(GetPriceReductionEntities());
            }
        }

        private static IEnumerable<ProductEntity> GetProductEntities()
        {
            var products = new List<ProductEntity>();
            var rnd = new Random();

            var p = new ProductEntity()
            {
                Id = "602d2149e773f2a3990b47f5",
                Name = "Grüner und blättriger Spinat",
                EntryDate = DateTime.UtcNow.AddDays(rnd.Next(-4, 0)),
                Price = 2.5
            };
            products.Add(p);

            p = new ProductEntity()
            {
                Id = "602d2149e773f2a3990b47f6",
                Name = "Frischer und gesunder Brokkoli",
                EntryDate = DateTime.UtcNow.AddDays(rnd.Next(-4, 0)),
                Price = 1.19
            };
            products.Add(p);

            p = new ProductEntity()
            {
                Id = "602d2149e773f2a3990b47f7",
                Name = "Uncle Ben's Rice",
                EntryDate = DateTime.UtcNow.AddDays(rnd.Next(-4, 0)),
                Price = 4.49
            };
            products.Add(p);

            p = new ProductEntity()
            {
                Id = "602d2149e773f2a3990b47f8",
                Name = "A pile of potatoes",
                EntryDate = DateTime.UtcNow.AddDays(rnd.Next(-4, 0)),
                Price = 7.25
            };
            
            products.Add(p);

            return products;
        }

        private static IEnumerable<PriceReductionEntity> GetPriceReductionEntities()
        {
            var priceReductions = new List<PriceReductionEntity>();

            var pR = new PriceReductionEntity() { DayOfWeek = 0, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 1, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 2, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 3, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 4, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 5, Reduction = 0.2 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 6, Reduction = 0.5 };
            priceReductions.Add(pR);

            return priceReductions;
        }
    }
}
