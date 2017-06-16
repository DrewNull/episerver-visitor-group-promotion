using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace Website.Models.Media
{
    [ContentType(
        DisplayName = "Image Media",
        GUID = "255632E0-5682-41A1-A52A-29D4B38F27CC")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageMedia : MediaData
    {
        [Display(
            Name = "Caption")]
        [UIHint(UIHint.LongString)]
        public virtual string Caption { get; set; }
    }
}