using DeliVeggie.Server.Repositories.Data;
using DeliVeggie.Server.Repositories.Interfaces;
using DeliVeggie.Server.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DeliVeggie.Server.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDeliVeggieContext _deliVeggieContext;

        #region Constructor(s)
        public ProductRepository()
        {
            _deliVeggieContext = new DeliVeggieContext();
        }
        #endregion

        #region Implemented interface method(s)
        public async Task<ProductEntity> GetProductDetailsAsync(string Id)
        {
            var p = await _deliVeggieContext.Products.Find(x => x.Id == Id).FirstOrDefaultAsync();
            return p;
        }

        public async Task<IEnumerable<ProductEntity>> ListProductsAsync()
        {
            var p = await _deliVeggieContext.Products.Find(x => true).ToListAsync();
            return p;
        }
        #endregion

        #region Private method(s)

        /// <summary>
        /// Initialises the list of mock products.
        /// </summary>
        /// <returns>List of product entities</returns>
        private IList<ProductEntity> InitializeProducts()
        {
            var products = new List<ProductEntity>();

            Random rnd = new Random();
            for (int i = 0; i <= rnd.Next(5, 10); i++)
            {
                var product = new ProductEntity()
                {
                    Id = i.ToString(),
                    Name = "Product -> " + rnd.Next(10, 100),
                    EntryDate = DateTime.Now,
                    Price = rnd.Next(10, 15)
                };
                products.Add(product);
            }

            return products;
        }
        #endregion
    }
}
