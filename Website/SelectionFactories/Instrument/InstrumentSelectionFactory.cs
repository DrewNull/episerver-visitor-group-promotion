using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Website.SelectionFactories.Instrument
{
    public class InstrumentSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new[]
            {
                new SelectItem
                {
                    Text = "Violin",
                    Value = "Violin"
                },
                new SelectItem
                {
                    Text = "Piano",
                    Value = "Piano"
                },
            };
        }
    }
}