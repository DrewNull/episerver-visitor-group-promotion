using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Website.Models.Pages;

namespace Website.Controllers.Pages
{
    public class CartPageController : PageController<CartPage>
    {
        public ActionResult Index(CartPage currentPage)
        {
            return this.View("~/Views/Pages/Cart/Index.cshtml", currentPage);
        }
    }
}