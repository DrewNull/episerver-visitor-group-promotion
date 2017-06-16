using System.Collections.Generic;
using Website.ViewModels.Variations.MusicLesson;

namespace Website.ViewModels.Nodes.CategoryNode
{
    public class CategoryNodeViewModel
    {
        public Models.Nodes.CategoryNode Model { get; set; }

        public string Url { get; set; }
        public IEnumerable<MusicLessonVariationViewModel> MusicLessonVariations { get; set; }
    }
}