using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Website.Models.Blocks
{
    [ContentType(
        DisplayName = "Hero Block",
        GUID = "2E44A1B2-6F34-4BF2-9083-E1E2F734AC66")]
    public class HeroBlock : BlockData
    {
        [Display(
            Name = "Background Image")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [Display(
            Name = "Heading")]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Subheading")]
        [UIHint(UIHint.LongString)]
        public virtual string Subheading { get; set; }

        [Display(
            Name = "Call to Action Link")]
        public virtual Url CallToActionLink { get; set; }

        [Display(
            Name = "Call to Action Text")]
        public virtual string CallToActionText { get; set; }
    }
}