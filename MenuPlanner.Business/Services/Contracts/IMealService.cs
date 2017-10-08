using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Services.Contracts
{
    public interface IMealService
    {
        IEnumerable<MealSchedule> GetMealScheduleForProfile(Profile profile);

        void AddOrUpdateMeals(IEnumerable<Meal> changedMeals, Profile currentProfile);
    }
}
