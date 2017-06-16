using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Website.SelectionFactories.Instrument;
using Website.SelectionFactories.Location;
using Website.SelectionFactories.Schedule;

namespace Website.Models.Variations
{
    //[ContentType(
    //    DisplayName = "Music Lesson Variation",
    //    GUID = "79953517-937A-46FF-8498-9B46330BEEAC")]
    public class MusicLessonVariation : VariationContent
    {
        [Display(
            Name = "Image")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
            Name = "Instrument")]
        [SelectOne(SelectionFactoryType = typeof(InstrumentSelectionFactory))]
        public virtual string Instrument { get; set; }

        [Display(
            Name = "Schedule")]
        [SelectOne(SelectionFactoryType = typeof(ScheduleSelectionFactory))]
        public virtual string Schedule { get; set; }

        [Display(
            Name = "Number of Lessons")]
        public virtual int NumberOfLessons { get; set; }

        [Display(
            Name = "Location")]
        [SelectOne(SelectionFactoryType = typeof(LocationSelectionFactory))]
        public virtual string Location { get; set; }
    }
}