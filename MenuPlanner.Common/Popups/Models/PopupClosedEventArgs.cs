using System;

namespace MenuPlanner.Common.Popups.Models
{
    public class PopupClosedEventArgs : EventArgs
    {
        public bool Success { get; set; }
    }
}
