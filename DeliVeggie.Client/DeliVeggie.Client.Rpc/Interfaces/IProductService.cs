using DeliVeggie.Queue.Messages;
using System.Threading.Tasks;

namespace DeliVeggie.Client.Rpc.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Make RPC call to fetch the product details from server over message queue.
        /// </summary>
        /// <param name="Id">Id of the Product</param>
        /// <returns>Product details response</returns>
        Task<ProductDetailsResponse> GetProductDetailsAsync(string Id);

        /// <summary>
        /// Make RPC call to fetch the products list from server over message queue.
        /// </summary>
        /// <returns>Products response</returns>
        Task<ProductsResponse> ListProductsAsync();
    }
}
