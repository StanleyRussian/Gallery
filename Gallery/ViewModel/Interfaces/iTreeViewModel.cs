using System.Collections.ObjectModel;

namespace Gallery
{
    interface iTreeViewModel
    {
        ObservableCollection<TreeBranchViewModel> Children
        { get; }
        string CurrentImageFullpath
        { get; set; }
    }
}