using System;
using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.Common.Popups.Managers
{
    public class PopupManager : IPopupManager
    {
        private Action<PopupClosedEventArgs> _toExecuteAction;

        public IEnumerable<Popup> Popups { get; }

        public Popup CurrentPopup { get; private set; }

        public event EventHandler<Popup> PopupChanged;

        public PopupManager(IEnumerable<Popup> popups)
        {
            Popups = popups;
        }

        public IPopupManager ShowPopup<T>(PopupParameters parameters = null) where T : Popup
        {
            var popup = GetPopup<T>();

            CurrentPopup = popup;
            CurrentPopup.Show(parameters);
            PopupChanged?.Invoke(this, popup);

            CurrentPopup.PopupClosed += CurrentPopup_PopupClosed;
            return this;
        }

        public void OnClose(Action<PopupClosedEventArgs> toExecuteAction)
        {
            _toExecuteAction = toExecuteAction;
        }

        private void CurrentPopup_PopupClosed(object sender, PopupClosedEventArgs e)
        {
            _toExecuteAction(e);
            CurrentPopup = null;
            PopupChanged?.Invoke(this, null);
        }

        private Popup GetPopup<T>() where T : Popup
        {
            return Popups.FirstOrDefault(p => p.GetType() == typeof(T));
        }
    }
}
