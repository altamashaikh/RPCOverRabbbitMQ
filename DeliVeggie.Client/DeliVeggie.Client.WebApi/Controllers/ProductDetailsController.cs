using DeliVeggie.Client.Rpc.Interfaces;
using DeliVeggie.Client.Rpc.Services;
using DeliVeggie.Client.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Client.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductDetailsController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        [Route("/productdetails")]
        public async Task<IEnumerable<Product>> Get()
        {
            var productResponse = await _productService.ListProductsAsync();

            var products = productResponse.ProductList.Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                EntryDate = x.EntryDate,
                PriceWithReduction = x.PriceWithReduction
            }).ToArray();

            return products;
        }

        [HttpGet]
        [Route("/product/{Id}")]
        public async Task<Product> Get(string Id)
        {
            var productResponse = await _productService.GetProductDetailsAsync(Id);

            var products = new Product() 
            {
                Id = productResponse.Product.Id,
                Name = productResponse.Product.Name,
                EntryDate = productResponse.Product.EntryDate,
                PriceWithReduction = productResponse.Product.PriceWithReduction
            };

            return products;
        }
    }
}
