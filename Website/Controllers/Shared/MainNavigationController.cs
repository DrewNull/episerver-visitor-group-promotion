using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Website.Models.Pages;
using Website.ViewModels;
using Website.ViewModels.Shared.MainNavigation;

namespace Website.Controllers.Shared
{
    public class MainNavigationController : Controller
    {
        private readonly Injected<IContentLoader> _contentLoader;
        private readonly Injected<UrlResolver> _urlResolver;

        public ActionResult Render()
        {
            var viewModel = new MainNavigationViewModel();

            var pages = this._contentLoader.Service.GetChildren<IContent>(ContentReference.StartPage);

            var links = pages
                .Select(x => new LinkViewModel
                {
                    Text = x.Name,
                    Url = this._urlResolver.Service.GetUrl(x.ContentLink)
                })
                .Where(x => !(x is CartPage))
                .ToList();

            viewModel.Links = links;

            var cartPage = pages.FirstOrDefault(x => x is CartPage);
            viewModel.CartUrl = this._urlResolver.Service.GetUrl(cartPage.ContentLink);

            return this.View("~/Views/Shared/Partials/MainNavigation/_MainNavigation.cshtml", viewModel);
        }
    }
}