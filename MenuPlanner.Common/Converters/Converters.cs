using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using LambdaConverters;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.Common.Converters
{
    public class Converters
    {
        public static readonly IValueConverter BoolToVisibility =
            ValueConverter.Create<bool, Visibility>(info => info.Value ? Visibility.Visible : Visibility.Collapsed);

        public static readonly IValueConverter NullToVisibility =
            ValueConverter.Create<object, Visibility>(info => info.Value != null ? Visibility.Visible : Visibility.Collapsed);

        public static readonly IValueConverter IsPlanningModeSelected =
            ValueConverter.Create<PlanningMode, bool, PlanningMode>(info => info.Value == info.Parameter);

        public static readonly IValueConverter ToTimeString =
            ValueConverter.Create<TimeSlot, string>(info => info.Value.ToText());

        public static readonly IMultiValueConverter IsTimeSlotSelected =
            MultiValueConverter.Create<object, bool>(args =>
            {
                if (args.Values[0] == null || args.Values[1] == null) return false;

                var list = args.Values[0] as IEnumerable<TimeSlot>;
                var elem = (TimeSlot)args.Values[1];

                return list != null && list.Contains(elem);
            });
    }
}
