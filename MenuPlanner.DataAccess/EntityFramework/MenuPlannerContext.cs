using MenuPlanner.DataAccess.EntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.DataAccess.EntityFramework
{
    public class MenuPlannerContext : DbContext
    {
        public DbSet<MealDto> Meals { get; set; }
        public DbSet<ProfileDto> Profiles { get; set; }
        public DbSet<StockItemDto> Stock { get; set; }
        public DbSet<ItemTypeDto> ItemTypes { get; set; }

        public MenuPlannerContext() : base("name=MenuPlannerConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MenuPlannerContext>());
        }
    }
}
