using MenuPlanner.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Repositories;

namespace MenuPlanner.Business.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<StockItem> GetStock(Profile profile)
        {
            return _stockRepository.GetStockForProfile(profile);
        }
    }
}
