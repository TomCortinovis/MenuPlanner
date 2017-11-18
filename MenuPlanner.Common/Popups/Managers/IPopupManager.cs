using System;
using System.Collections.Generic;
using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.Common.Popups.Managers
{
    public interface IPopupManager
    {
        IEnumerable<Popup> Popups { get; }

        Popup CurrentPopup { get; }

        event EventHandler<Popup> PopupChanged;

        IPopupManager ShowPopup<T>(PopupParameters parameters = null) where T : Popup;

        IPopupManager ShowMessage(string message);

        void OnClose(Action<PopupClosedEventArgs> toExecuteAction);
    }
}
