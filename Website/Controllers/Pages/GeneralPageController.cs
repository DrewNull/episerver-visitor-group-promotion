using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Website.Models.Pages;

namespace Website.Controllers.Pages
{
    public class GeneralPageController : PageController<GeneralPage>
    {
        public ActionResult Index(GeneralPage currentPage)
        {
            return this.View("~/Views/Pages/General/Index.cshtml", currentPage);
        }
    }
}