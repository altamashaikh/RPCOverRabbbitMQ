using DeliVeggie.Client.Rpc.Interfaces;
using DeliVeggie.Queue.Messages;
using EasyNetQ;
using System;
using System.Threading.Tasks;

namespace DeliVeggie.Client.Rpc.Services
{
    public class ProductService : IProductService
    {
        public async Task<ProductDetailsResponse> GetProductDetailsAsync(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException($"Invalid product id.");
            }

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var request = new ProductDetailsRequest() { ProductId = productId };
                var response = await bus.Rpc.RequestAsync<ProductDetailsRequest, ProductDetailsResponse>(request);
                if (response == null)
                {
                    throw new NullReferenceException($"Product [id: {productId}] no found.");
                }
                return response;
            }
        }

        public async Task<ProductsResponse> ListProductsAsync()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var request = new ProductsRequest();
                var response = await bus.Rpc.RequestAsync<ProductsRequest, ProductsResponse>(request);
                return response;
            }
        }
    }
}
