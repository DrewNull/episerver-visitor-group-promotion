using System.Collections.Generic;

namespace Website.ViewModels.Shared.MainNavigation
{
    public class MainNavigationViewModel
    {
        public IEnumerable<LinkViewModel> Links { get; set; }

        public string CartUrl { get; set; }
    }
}