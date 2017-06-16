using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Website.Models.Blocks;
using Website.ViewModels.Blocks.Hero;

namespace Website.Controllers.Blocks
{
    [TemplateDescriptor(Default = true, Inherited = true)]
    public class HeroBlockController : BlockController<HeroBlock>
    {
        private Injected<UrlResolver> _urlResolver;
        public override ActionResult Index(HeroBlock currentContent)
        {
            var viewModel = this.GetViewModel(currentContent);
            return this.View("~/Views/Blocks/Hero/_HeroBlock.cshtml", viewModel);
        }

        private HeroBlockViewModel GetViewModel(HeroBlock block)
        {
            var viewModel = new HeroBlockViewModel();
            viewModel.Block = block;
            return viewModel;
        }
    }
}