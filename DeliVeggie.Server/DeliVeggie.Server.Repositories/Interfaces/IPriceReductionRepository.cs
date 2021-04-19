using DeliVeggie.Server.Repositories.Models;
using System;
using System.Threading.Tasks;

namespace DeliVeggie.Server.Repositories.Interfaces
{
    public interface IPriceReductionRepository
    {
        /// <summary>
        /// Get the price reduction for product entity, based on the day of the week, starting Sunday = 0
        /// </summary>
        /// <param name="dayOfWeek">Day of the week.</param>
        /// <returns>Price reduction. null when not found.</returns>
        Task<PriceReductionEntity> GetPriceReductionAsync(DayOfWeek dayOfWeek);        
    }
}
