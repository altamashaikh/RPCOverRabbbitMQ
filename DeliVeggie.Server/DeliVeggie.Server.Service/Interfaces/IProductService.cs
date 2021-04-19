using DeliVeggie.Server.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggie.Server.Service.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Get the details of the product by its id and calculates price reduction by day of the week.
        /// </summary>
        /// <param name="Id">Id of the product</param>
        /// <returns>Product entity details. null when not found.</returns>
        Task<ProductDto> GetProductDetailsAsync(string Id);

        /// <summary>
        /// Lists all the known products with thier calculated reduced price.
        /// </summary>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductDto>> ListProductsAsync();
    }
}
