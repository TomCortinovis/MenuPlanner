using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.Common.Popups.ViewModels
{
    public class MessageViewModel : Popup
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { Set(ref _message, value); }
        }

        public override void Show(PopupParameters parameters)
        {
            base.Show(parameters);

            Message = (Parameters as MessagePopupParameters).Message;
        }
    }
}
