using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Website.Models.Blocks;

namespace Website.Controllers.Blocks
{
    [TemplateDescriptor(Default = true, Inherited = true)]
    public class RichTextBlockController : BlockController<RichTextBlock>
    {
        public override ActionResult Index(RichTextBlock currentContent)
        {
            return this.View("~/Views/Blocks/RichText/_RichTextBlock.cshtml", currentContent);
        }
    }
}