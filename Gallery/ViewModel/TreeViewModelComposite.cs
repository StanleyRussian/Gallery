using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    abstract class TreeViewModelItem
    {
        readonly TreeBranchViewModel Parent;

        protected TreeViewModelItem(TreeBranchViewModel parent)
        {
            Parent = parent;
        }
    }

    class TreeBranchViewModel : TreeViewModelItem
    {
        readonly ObservableCollection<TreeViewModelItem> Children;

        readonly TreeBranch ModelBranch;

        bool _isExpanded;
        bool _isSelected;

        public TreeBranchViewModel(TreeBranch branch)
            : this(branch, null)
        {
        }

        private TreeBranchViewModel(TreeBranch branch, TreeBranchViewModel parent)
            : base(parent)
        {
            ModelBranch = branch;

            Children = new ObservableCollection<TreeViewModelItem>();
            foreach (var child in ModelBranch.Children)
            {
                if (child is TreeBranch)
                    Children.Add(new TreeBranchViewModel(child as TreeBranch));
                else if (child is TreeLeaf)
                    Children.Add(new TreeLeafViewModel(child as TreeLeaf));
            }
        }

    }

    class TreeLeafViewModel : TreeViewModelItem
    {
        readonly TreeLeaf ModelLeaf;

        bool _isSelected;

        public TreeLeafViewModel(TreeLeaf branch)
            : this(branch, null)
        {
        }

        private TreeLeafViewModel(TreeLeaf leaf, TreeBranchViewModel parent)
            : base(parent)
        {
            ModelLeaf = leaf;
        }

    }
}
