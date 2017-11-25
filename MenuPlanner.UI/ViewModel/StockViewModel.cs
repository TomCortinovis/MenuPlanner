using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Common;
using MenuPlanner.UI.Models;

namespace MenuPlanner.UI.ViewModel
{
    public class StockViewModel : BaseViewModel, IPage
    {
        public StockViewModel(ISessionService session) : base(session)
        {
        }

        public string Name => "Stock";

        public int Order => 2;
    }
}
