using EasyNetQ;
using System;
using System.Threading.Tasks;
using System.Linq;
using DeliVeggie.Queue.Messages;
using DeliVeggie.Server.Service.Interfaces;
using DeliVeggie.Server.Service.Services;

namespace DeliVeggie.Listener
{
    class Program
    {
        private static IProductService _productService;
        /// <summary>
        /// Entry method that will be the starting point for the DeliVeggie Server Listener application 
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            _productService = new ProductService();

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Rpc.RespondAsync<ProductDetailsRequest, ProductDetailsResponse>(request =>
                {
                    var response = GetProductDetailsAsync(request);
                    return response;
                });

                bus.Rpc.RespondAsync<ProductsRequest, ProductsResponse>(request =>
                {
                    var response = ListProductsAsync(request);
                    return response;
                });

                Console.WriteLine("Service started and listening for requests.");
                Console.WriteLine("Hit <return> to quit.");
                Console.ReadLine();
            }
        }


        /// <summary>
        /// Request handler for product details
        /// </summary>
        /// <param name="request">Product details request</param>
        /// <returns>Product details response</returns>
        private async static Task<ProductDetailsResponse> GetProductDetailsAsync(ProductDetailsRequest request)
        {
            ProductDetailsResponse response = null;
            try
            {
                var productDto = await _productService.GetProductDetailsAsync(request.ProductId);

                var product = new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    EntryDate = productDto.EntryDate,
                    PriceWithReduction = productDto.PriceWithReduction
                };

                //Generate the response message with product info and return
                response = new ProductDetailsResponse() { Product = product };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        /// <summary>
        /// List the products
        /// </summary>
        /// <param name="request">Products request</param>
        /// <returns>Products response</returns>
        private async static Task<ProductsResponse> ListProductsAsync(ProductsRequest request)
        {
            ProductsResponse response = null;
            try
            {
                var productDtos = await _productService.ListProductsAsync();

                var products = productDtos.Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    EntryDate = x.EntryDate,
                    PriceWithReduction = x.PriceWithReduction
                }).ToList();

                response = new ProductsResponse() { ProductList = products };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;

        }
    }
}