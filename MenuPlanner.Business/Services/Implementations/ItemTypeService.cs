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
    public class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;

        public ItemTypeService(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        public IEnumerable<ItemType> GetAllTypes()
        {
            return _itemTypeRepository.GetAllItemTypes();
        }
    }
}
