using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Website.Models.Nodes;
using Website.Models.Variations;
using Website.Services;
using Website.ViewModels.Nodes.CategoryNode;

namespace Website.Controllers.Nodes
{
    public class CategoryNodeController : ContentController<CategoryNode>
    {
        private readonly Injected<MusicLessonVariationService> _service;
        private readonly Injected<IContentLoader> _contentLoader;

        public ActionResult Index(CategoryNode currentContent)
        {
            return this.View("~/Views/Nodes/Category/Index.cshtml", this.GetViewModel(currentContent));
        }

        private CategoryNodeViewModel GetViewModel(CategoryNode currentContent)
        {
            var viewModel = new CategoryNodeViewModel();
            viewModel.Model = currentContent;
            var variations = this._contentLoader.Service.GetChildren<MusicLessonVariation>(currentContent.ContentLink);
            if (variations != null)
            {
                var variationViewModels = variations.Select(x => this._service.Service.GetViewModel(x));
                viewModel.MusicLessonVariations = variationViewModels;
            }
            return viewModel;
        }
    }
}