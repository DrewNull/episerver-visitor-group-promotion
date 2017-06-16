using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Website.Models.Nodes;

namespace Website.Models.Blocks
{
    [ContentType(
        DisplayName = "Category Node Rollup Block",
        GUID = "9FDA472B-F4D8-4573-96C6-2701157D6D9E")]
    public class CategoryNodeRollupBlock : BlockData
    {
        [Display(
            Name = "Heading")]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Subheading")]
        [UIHint(UIHint.LongString)]
        public virtual string Subheading { get; set; }

        [Display(
            Name = "Category Nodes")]
        [AllowedTypes(typeof(CategoryNode))]
        public virtual IList<ContentReference> CategoryNodes { get; set; }
    }
}