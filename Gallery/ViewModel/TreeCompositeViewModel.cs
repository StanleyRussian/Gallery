using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    abstract class TreeItemViewModel
    {
        readonly TreeBranchViewModel Parent;
        readonly TreeItem ModelItem;

        protected TreeItemViewModel(TreeItem item, TreeBranchViewModel parent)
        {
            Parent = parent;
            ModelItem = item;
        }

        public string Fullpath
        {
            get { return ModelItem.Fullpath; }
        }

        public string Name
        {
            get { return ModelItem.Name; }
        }
    }

    class TreeBranchViewModel : TreeItemViewModel
    {

        readonly TreeBranch ModelBranch;

        public bool _isExpanded;
        public bool _isSelected;

        public ObservableCollection<TreeItemViewModel> Children
        {
            get; private set;
        }

        public TreeBranchViewModel(TreeBranch branch)
            : this(branch, null)
        {
        }

        private TreeBranchViewModel(TreeBranch branch, TreeBranchViewModel parent)
            : base(branch, parent)
        {
            ModelBranch = branch;

            Children = new ObservableCollection<TreeItemViewModel>();
            foreach (var child in ModelBranch.Children)
            {
                if (child is TreeBranch)
                    Children.Add(new TreeBranchViewModel(child as TreeBranch));
                else if (child is TreeLeaf)
                    Children.Add(new TreeLeafViewModel(child as TreeLeaf));
            }
        }
    }

    class TreeLeafViewModel : TreeItemViewModel
    {
        readonly TreeLeaf ModelLeaf;

        bool _isSelected;

        public TreeLeafViewModel(TreeLeaf branch)
            : this(branch, null)
        {
        }

        private TreeLeafViewModel(TreeLeaf leaf, TreeBranchViewModel parent)
            : base(leaf, parent)
        {
            ModelLeaf = leaf;
        }

    }
}
