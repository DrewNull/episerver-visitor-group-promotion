using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Website.Models.Blocks;
using Website.Models.Variations;
using Website.Services;
using Website.ViewModels.Blocks.MusicLessonVariationRollup;

namespace Website.Controllers.Blocks
{
    [TemplateDescriptor(Default = true, Inherited = true)]
    public class MusicLessonVariationRollupBlockController : BlockController<MusicLessonVariationRollupBlock>
    {
        private readonly Injected<MusicLessonVariationService> _service;
        private readonly Injected<IContentLoader> _contentLoader;
        public override ActionResult Index(MusicLessonVariationRollupBlock currentContent)
        {
            var viewModel = this.GetViewModel(currentContent);
            return this.View("~/Views/Blocks/MusicLessonVariationRollup/_MusicLessonVariationRollupBlock.cshtml", viewModel);
        }

        private MusicLessonVariationRollupBlockViewModel GetViewModel(MusicLessonVariationRollupBlock block)
        {
            var variations = block.MusicLessonVariations.Select(x => this._contentLoader.Service.Get<MusicLessonVariation>(x));
            var variationViewModels = variations.Select(x => this._service.Service.GetViewModel(x));
            var viewModel = new MusicLessonVariationRollupBlockViewModel();
            viewModel.Block = block;
            viewModel.MusicLessonVariations = variationViewModels;
            return viewModel;
        }
    }
}