using DeliVeggie.Server.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggie.Server.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get the details of the product entity by its id.
        /// </summary>
        /// <param name="Id">Id of the product</param>
        /// <returns>Product entity details. null when not found.</returns>
        Task<ProductEntity> GetProductDetailsAsync(string Id);

        /// <summary>
        /// Lists all the known product entities.
        /// </summary>
        /// <returns>List of product entities</returns>
        Task<IEnumerable<ProductEntity>> ListProductsAsync();
    }
}
