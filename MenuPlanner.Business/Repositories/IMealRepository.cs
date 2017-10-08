using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.Business.Repositories
{
    public interface IMealRepository
    {
        IEnumerable<Meal> GetAllMealsForProfile(Profile profile);

        void AddMeal(Meal meal, Profile profile);

        void UpdateMeal(Meal meal, Profile profile);

        bool DoesMealAlreadyExist(DateTime day, TimeSlot time, Profile profile);
    }
}
