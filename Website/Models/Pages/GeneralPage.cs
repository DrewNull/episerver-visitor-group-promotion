using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Website.Models.Pages
{
    [ContentType(
        DisplayName = "General Page",
        GUID = "4956127C-91A2-49C1-B70A-A774E96477F4")]
    public class GeneralPage : PageData
    {
        [Display(
            Name = "Main Content")]
        public virtual ContentArea MainContent { get; set; }
    }
}