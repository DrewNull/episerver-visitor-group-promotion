using System.Linq;
using System.Web.Mvc;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;
using Website.ViewModels.Shared.Debugger;

namespace Website.Controllers.Shared
{
    public class DebuggerController : Controller
    {
        private readonly Injected<IVisitorGroupRepository> _visitorGroupRepository;
        private readonly Injected<IVisitorGroupRoleRepository> _visitorGroupRoleRepository;

        public ActionResult GetStatus()
        {
            return this.View("~/Views/Shared/Partials/Debugger/_Debugger.cshtml", this.GetViewModel());
        }

        private DebuggerViewModel GetViewModel()
        {
            // get active visitor groups
            var user = this.HttpContext.User;
            var allVisitorGroups = this._visitorGroupRepository.Service.List();
            var visitorGroupHelper = new VisitorGroupHelper(this._visitorGroupRoleRepository.Service);
            var activeVisitorGroups = allVisitorGroups
                .Where(x => visitorGroupHelper.IsPrincipalInGroup(user, x.Name))
                .Select(x => $"'{x.Name}'")
                .ToList();

            // compose view model
            var script = activeVisitorGroups.Any()
                ? $"console.log('Active Visitor Groups: ' + {string.Join(", ", activeVisitorGroups)});"
                : "console.log('There are no active Visitor Groups');";
            var viewModel = new DebuggerViewModel
            {
                Script = script
            };

            return viewModel;
        }
    }
}