using System.Collections.Generic;
using Website.Models.Blocks;
using Website.ViewModels.Nodes.CategoryNode;

namespace Website.ViewModels.Blocks.CategoryNodeRollup
{
    public class CategoryNodeRollupBlockViewModel
    {
        public CategoryNodeRollupBlock Block { get; set; }

        public IEnumerable<CategoryNodeViewModel> CategoryNodes { get; set; }
    }
}