using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class TreeBranchViewModel
    {
        readonly ObservableCollection<TreeBranchViewModel> _children;
        readonly TreeBranchViewModel _parent;
        readonly TreeBranch _branch;

        bool _isExpanded;
        bool _isSelected;

        public TreeBranchViewModel(TreeBranch branch)
            : this(branch, null)
        {
        }

        private TreeBranchViewModel(TreeBranch branch, TreeBranchViewModel parent)
        {
            _branch = branch;
            _parent = parent;

            _children = new ReadOnlyCollection<TreeBranchViewModel>(
                    (from child in _branch.Children
                     select new TreeBranchViewModel(child, this))
                     .ToList<TreeBranchViewModel>());
        }

    }
}
