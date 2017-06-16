using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Website.Models.Pages
{
    [ContentType(
        DisplayName = "Home Page",
        GUID = "491493B5-3E57-4853-805C-DC4EC5954468")]
    public class HomePage : PageData
    {
        [Display(
            Name = "Main Content")]
        public virtual ContentArea MainContent { get; set; }
    }
}