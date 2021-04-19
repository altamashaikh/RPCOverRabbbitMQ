using DeliVeggie.Server.Repositories.Interfaces;
using DeliVeggie.Server.Repositories.Repositories;
using DeliVeggie.Server.Service.Interfaces;
using DeliVeggie.Server.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Server.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPriceReductionRepository _priceReductionRepository;

        #region Constructor(s)
        public ProductService()
        {
            //Todo: ProductRepository must be injected to the service.
            _productRepository = new ProductRepository();
            _priceReductionRepository = new PriceReductionRepository();
        }
        #endregion

        #region Implemented interface method(s)
        public async Task<ProductDto> GetProductDetailsAsync(string Id)
        {
            //Get the day of the week
            var dayOfWeek = DateTime.Now.DayOfWeek;

            //Get the reduction of price
            var pR = await _priceReductionRepository.GetPriceReductionAsync(dayOfWeek);

            if (pR == null)
            {
                throw new Exception($"Price reduction for the {dayOfWeek} not found.");
            }

            //get the product entity
            var productEntity = await _productRepository.GetProductDetailsAsync(Id);

            if (productEntity == null)
            {
                throw new Exception($"Project [id: {Id}] not found.");
            }

            var productDto = new ProductDto()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                EntryDate = productEntity.EntryDate,
                PriceWithReduction = productEntity.Price * (1.0 - pR.Reduction)
            };

            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> ListProductsAsync()
        {
            //Get the day of the week
            var dayOfWeek = DateTime.Now.DayOfWeek;

            //Get the reduction of price
            var pR = await _priceReductionRepository.GetPriceReductionAsync(dayOfWeek);

            if (pR == null)
            {
                throw new Exception($"Price reduction for the {dayOfWeek} not found.");
            }

            //List the products
            var productEntities = await _productRepository.ListProductsAsync();

            //Map the entities to dtos
            var productDtos = productEntities.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                EntryDate = x.EntryDate,
                PriceWithReduction = x.Price * (1.0 - pR.Reduction)
            }).ToList();

            return productDtos;
        }

        #endregion
    }
}
