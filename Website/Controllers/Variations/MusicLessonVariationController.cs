using System.Web.Mvc;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Website.Models.Variations;
using Website.Services;

namespace Website.Controllers.Variations
{
    public class MusicLessonVariationController : ContentController<MusicLessonVariation>
    {
        private Injected<MusicLessonVariationService> _service;

        public ActionResult Index(MusicLessonVariation currentContent)
        {
            return this.View("~/Views/Variations/MusicLesson/Index.cshtml", _service.Service.GetViewModel(currentContent));
        }
    }
}