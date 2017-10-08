using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.UI.Models
{
    public class MealScheduleModel : ObservableObject
    {
        private DateTime _day;
        public DateTime Day
        {
            get { return _day; }
            set { Set(ref _day, value); }
        }

        private List<MealModel> _meals;
        public List<MealModel> Meals
        {
            get { return _meals; }
            set { Set(ref _meals, value); }
        }
    }
}
