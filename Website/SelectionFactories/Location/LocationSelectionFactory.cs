using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Website.SelectionFactories.Location
{
    public class LocationSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new[]
            {
                new SelectItem
                {
                    Text = "Studio",
                    Value = "Studio"
                },
                new SelectItem
                {
                    Text = "Online",
                    Value = "Online"
                },
            };
        }
    }
}