using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Website.Models.Blocks;
using Website.Models.Nodes;
using Website.ViewModels.Blocks.CategoryNodeRollup;
using Website.ViewModels.Nodes.CategoryNode;

namespace Website.Controllers.Blocks
{
    [TemplateDescriptor(Default = true, Inherited = true)]
    public class CategoryNodeRollupBlockController : BlockController<CategoryNodeRollupBlock>
    {
        private Injected<IContentLoader> _contentLoader;
        private Injected<UrlResolver> _urlResolver;
        public override ActionResult Index(CategoryNodeRollupBlock currentContent)
        {
            var viewModel = this.GetViewModel(currentContent);
            return this.View("~/Views/Blocks/CategoryNodeRollup/_CategoryNodeRollupBlock.cshtml", viewModel);
        }

        private CategoryNodeRollupBlockViewModel GetViewModel(CategoryNodeRollupBlock block)
        {
            var viewModel = new CategoryNodeRollupBlockViewModel();
            viewModel.Block = block;

            var categoryNodes = block.CategoryNodes.Select(x => this._contentLoader.Service.Get<CategoryNode>(x));

            viewModel.CategoryNodes = categoryNodes.Select(x =>
            {
                var categoryNodeViewModel = new CategoryNodeViewModel();
                categoryNodeViewModel.Model = x;
                categoryNodeViewModel.Url = this._urlResolver.Service.GetUrl(x.ContentLink);
                return categoryNodeViewModel;
            });

            return viewModel;
        }
    }
}