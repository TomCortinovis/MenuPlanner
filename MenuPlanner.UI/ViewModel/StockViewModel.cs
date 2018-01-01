using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Common;
using MenuPlanner.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MenuPlanner.UI.ViewModel
{
    public class StockViewModel : BaseViewModel, IPage
    {
        private readonly IStockService _stockService;
        private readonly IItemTypeService _itemTypeService;

        public StockViewModel(ISessionService session, IStockService stockService, IItemTypeService itemTypeService) : base(session)
        {
            Types = _itemTypeService.GetAllTypes().ToList();

            session.ProfileChanged += Session_ProfileChanged;
            _stockService = stockService;
            _itemTypeService = itemTypeService;
        }

        public string Name => "Stock";

        public int Order => 2;

        public ObservableCollection<StockItem> Stock { get; set; }

        public List<ItemType> Types;

        private void Session_ProfileChanged(object sender, Profile e)
        {
            Stock = new ObservableCollection<StockItem>(_stockService.GetStock(e));
        }
    }
}
