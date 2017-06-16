using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Website.Models.Pages
{
    [ContentType(
        DisplayName = "Cart Page",
        GUID = "02C03F3C-76A1-4D0D-9F1F-FAE142A8168C")]
    public class CartPage : PageData
    {
    }
}