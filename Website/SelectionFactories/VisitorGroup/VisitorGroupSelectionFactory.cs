using System.Collections.Generic;
using System.Linq;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using ISelectionFactory = EPiServer.Shell.ObjectEditing.ISelectionFactory;

namespace Website.SelectionFactories.VisitorGroup
{
    public class VisitorGroupSelectionFactory : ISelectionFactory
    {
        private readonly Injected<IVisitorGroupRepository> _visitorGroupRepository;

        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var visitorGroups = this._visitorGroupRepository.Service.List();

            var selections = visitorGroups.Select(x => new SelectItem()
            {
                Text = x.Name,
                Value = x.Id
            });

            return selections;
        }
    }
}