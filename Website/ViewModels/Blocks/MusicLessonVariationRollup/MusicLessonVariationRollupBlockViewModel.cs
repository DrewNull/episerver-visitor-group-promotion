using System.Collections.Generic;
using Website.Models.Blocks;
using Website.ViewModels.Variations.MusicLesson;

namespace Website.ViewModels.Blocks.MusicLessonVariationRollup
{
    public class MusicLessonVariationRollupBlockViewModel
    {
        public MusicLessonVariationRollupBlock Block { get; set; }
        public IEnumerable<MusicLessonVariationViewModel> MusicLessonVariations { get; set; }
    }
}