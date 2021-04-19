using DeliVeggie.Server.Repositories.Models;
using MongoDB.Driver;

namespace DeliVeggie.Server.Repositories.Data
{
    public interface IDeliVeggieContext
    {
        IMongoCollection<ProductEntity> Products { get;  }
        IMongoCollection<PriceReductionEntity> PriceReductions { get; }
    }
}
