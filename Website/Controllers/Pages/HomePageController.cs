using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Website.Models.Pages;

namespace Website.Controllers.Pages
{
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            return this.View("~/Views/Pages/Home/Index.cshtml", currentPage);
        }
    }
}