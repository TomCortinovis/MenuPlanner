using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Repositories
{
    public interface IItemTypeRepository
    {
        IEnumerable<ItemType> GetAllItemTypes();
    }
}
