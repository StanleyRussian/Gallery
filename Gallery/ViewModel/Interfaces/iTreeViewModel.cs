using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gallery
{
    interface iTreeViewModel
    {
        ObservableCollection<TreeBranchViewModel> Children
        { get; }

        void ExpandNode(string name);
    }
}