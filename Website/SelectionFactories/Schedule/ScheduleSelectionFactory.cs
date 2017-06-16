using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Website.SelectionFactories.Schedule
{
    public class ScheduleSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new[]
            {
                new SelectItem
                {
                    Text = "One-time",
                    Value = "One-time"
                },
                new SelectItem
                {
                   Text = "1 Month",
                   Value = "1 Month"
                },
                new SelectItem
                {
                    Text = "Fall Season",
                    Value = "Fall Season"
                },
                new SelectItem
                {
                    Text = "Spring Season",
                    Value = "Spring Season"
                },
                new SelectItem
                {
                    Text = "Summer Season",
                    Value = "Summer Season"
                },
                new SelectItem
                {
                    Text = "1 Year",
                    Value = "1 Year"
                },
            };
        }
    }
}