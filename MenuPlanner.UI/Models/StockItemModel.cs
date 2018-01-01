using GalaSoft.MvvmLight;
using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.UI.Models
{
    public class StockItemModel : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { Set(ref _quantity, value); }
        }

        private ItemType _type;
        public ItemType Type
        {
            get { return _type; }
            set { Set(ref _type, value); }
        }
    }
}
