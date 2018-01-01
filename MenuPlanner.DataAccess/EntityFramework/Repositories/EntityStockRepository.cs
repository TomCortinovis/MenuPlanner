using MenuPlanner.Business.Repositories;
using System.Collections.Generic;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.DataAccess.EntityFramework.Domain;
using AutoMapper;
using System.Linq;

namespace MenuPlanner.DataAccess.EntityFramework.Repositories
{
    public class EntityStockRepository : IStockRepository
    {
        public IEnumerable<StockItem> GetStockForProfile(Business.BusinessObjects.Profile profile)
        {
            var profileDto = Mapper.Map<Business.BusinessObjects.Profile, ProfileDto>(profile);

            using (var context = new MenuPlannerContext())
            {
                return Mapper.Map<List<StockItem>>(context.Stock.Where(m => m.Profile.Name == profileDto.Name));
            }
        }
    }
}
