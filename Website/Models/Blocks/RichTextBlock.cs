using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Website.Models.Blocks
{
    [ContentType(
        DisplayName = "Rich-Text Block",
        GUID = "2A0809B9-8730-4164-8230-4060E92B8522")]
    public class RichTextBlock : BlockData
    {
        [Display(
            Name = "Rich-Text")]
        public virtual XhtmlString RichText { get; set; }
    }
}