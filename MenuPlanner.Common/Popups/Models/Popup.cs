using System;
using GalaSoft.MvvmLight;

namespace MenuPlanner.Common.Popups.Models
{
    public abstract class Popup : ViewModelBase
    {
        public event EventHandler<PopupClosedEventArgs> PopupClosed;

        public PopupParameters Parameters { get; set; }

        public virtual void Show(PopupParameters parameters)
        {
            Parameters = parameters;
        }

        public virtual void Close(bool success)
        {
            PopupClosed?.Invoke(this, new PopupClosedEventArgs { Success = success });
        }
    }
}
