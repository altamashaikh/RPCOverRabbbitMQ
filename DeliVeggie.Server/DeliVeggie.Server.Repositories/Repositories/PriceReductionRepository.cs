using DeliVeggie.Server.Repositories.Data;
using DeliVeggie.Server.Repositories.Interfaces;
using DeliVeggie.Server.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DeliVeggie.Server.Repositories.Repositories
{
    public class PriceReductionRepository : IPriceReductionRepository
    {
        private readonly IDeliVeggieContext _deliVeggieContext;

        #region Constructor(s)
        public PriceReductionRepository()
        {
            _deliVeggieContext = new DeliVeggieContext();
        }
        #endregion

        #region Implementated interface method(s)       
        public async Task<PriceReductionEntity> GetPriceReductionAsync(DayOfWeek dayOfWeek)
        {
            return await _deliVeggieContext.PriceReductions.Find(x => x.DayOfWeek == (int)dayOfWeek).FirstOrDefaultAsync();
        }       
        #endregion

        #region Private method(s)

        /// <summary>
        /// Initialy used for mocking, not required anymore
        /// </summary>
        /// <returns></returns>
        private IList<PriceReductionEntity> InitializePriceReductionList()
        {
            var priceReductions = new List<PriceReductionEntity>();

            var pR = new PriceReductionEntity() { DayOfWeek = 0, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 1, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 2, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 3, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 4, Reduction = 0 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 5, Reduction = 0.2 };
            priceReductions.Add(pR);

            pR = new PriceReductionEntity() { DayOfWeek = 6, Reduction = 0.5 };
            priceReductions.Add(pR);

            return priceReductions;
        }
        #endregion
    }
}
