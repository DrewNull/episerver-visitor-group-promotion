using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Website.Models.Variations;

namespace Website.Models.Blocks
{
    [ContentType(
        DisplayName = "Music Lesson Variation Rollup Block",
        GUID = "D1460B74-38A4-4E74-B1F3-59B4B02A41A1")]
    public class MusicLessonVariationRollupBlock : BlockData
    {
        [Display(
            Name = "Heading")]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Subheading")]
        [UIHint(UIHint.LongString)]
        public virtual string Subheading { get; set; }

        [Display(
            Name = "Music Lesson Variation")]
        [AllowedTypes(typeof(MusicLessonVariation))]
        public virtual IList<ContentReference> MusicLessonVariations { get; set; }
    }
}