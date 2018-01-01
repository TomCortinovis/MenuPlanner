using MenuPlanner.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Business.BusinessObjects;
using AutoMapper;

namespace MenuPlanner.DataAccess.EntityFramework.Repositories
{
    public class EntityItemTypeRepository : IItemTypeRepository
    {
        public IEnumerable<ItemType> GetAllItemTypes()
        {
            using (var context = new MenuPlannerContext())
            {
                return Mapper.Map<List<ItemType>>(context.ItemTypes);
            }
        }
    }
}
