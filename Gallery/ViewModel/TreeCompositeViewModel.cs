using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    abstract class TreeItemViewModel: INotifyPropertyChanged
    {
        public TreeBranchViewModel Parent
        { get; private set; }

        readonly TreeItem _modelItem;

        protected TreeItemViewModel(TreeItem item, TreeBranchViewModel parent)
        {
            Parent = parent;
            _modelItem = item;
        }

        #region Model Properties

        public string Fullpath
        {
            get { return _modelItem.Fullpath; }
        }

        public string Name
        {
            get { return _modelItem.Name; }
        }

        #endregion

        #region UI Properties and INotifyPropertyChanged implementation

        private bool _isSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }

    class TreeBranchViewModel : TreeItemViewModel
    {

        readonly TreeBranch _modelBranch;

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
            _modelBranch = branch;

            Children = new ObservableCollection<TreeItemViewModel>();
            foreach (var child in _modelBranch.Children)
            {
                if (child is TreeBranch)
                    Children.Add(new TreeBranchViewModel(child as TreeBranch));
                else if (child is TreeLeaf)
                    Children.Add(new TreeLeafViewModel(child as TreeLeaf));
            }
        }

        #region UI Properties

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_isExpanded && Parent != null)
                    Parent.IsExpanded = true;
            }
        }

        #endregion
    }

    class TreeLeafViewModel : TreeItemViewModel
    {
        readonly TreeLeaf _modelLeaf;

        public TreeLeafViewModel(TreeLeaf branch)
            : this(branch, null)
        {
        }

        private TreeLeafViewModel(TreeLeaf leaf, TreeBranchViewModel parent)
            : base(leaf, parent)
        {
            _modelLeaf = leaf;
        }

    }
}
