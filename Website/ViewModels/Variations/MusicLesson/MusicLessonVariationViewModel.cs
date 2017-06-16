using Website.Models.Variations;

namespace Website.ViewModels.Variations.MusicLesson
{
    public class MusicLessonVariationViewModel
    {
        public MusicLessonVariation Model { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal ListPrice { get; set; }

        public bool HasDiscount => this.DiscountPrice != this.ListPrice;

        public string Url { get; set; }
    }
}