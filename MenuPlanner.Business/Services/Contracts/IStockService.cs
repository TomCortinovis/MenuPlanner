using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Services.Contracts
{
    public interface IStockService
    {
        IEnumerable<StockItem> GetStock(Profile profile);
    }
}
