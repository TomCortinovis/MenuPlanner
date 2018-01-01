using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.BusinessObjects
{
    public class StockItem
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public ItemType Type { get; set; }
    }
}
