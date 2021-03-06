﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Gallery
{
    abstract class TreeItemViewModel : INotifyPropertyChanged
    {
        protected iTreeViewModel _governor;
        public TreeBranchViewModel Parent
        { get; private set; }

        readonly TreeItem _modelItem;

        protected TreeItemViewModel(TreeItem item, TreeBranchViewModel parent, iTreeViewModel governor)
        {
            Parent = parent;
            _modelItem = item;
            _governor = governor;
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

        protected bool isSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
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

        public TreeBranchViewModel(TreeBranch branch, iTreeViewModel governor)
            : this(branch, null, governor)
        {
        }

        private TreeBranchViewModel(TreeBranch branch, TreeBranchViewModel parent, iTreeViewModel governor)
            : base(branch, parent, governor)
        {
            _modelBranch = branch;

            Children = new ObservableCollection<TreeItemViewModel>();
            foreach (var child in _modelBranch.Children)
            {
                if (child is TreeBranch)
                    Children.Add(new TreeBranchViewModel(child as TreeBranch,_governor));
                else if (child is TreeLeaf)
                    Children.Add(new TreeLeafViewModel(child as TreeLeaf, _governor));
            }
        }

        #region UI Properties

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (isExpanded && Parent != null)
                    Parent.IsExpanded = true;

                // Refresh expanding node childen
                if (isExpanded)
                {
                    _modelBranch.Expand();
                    Children.Clear();
                    foreach (var child in _modelBranch.Children)
                    {
                        if (child is TreeBranch)
                            Children.Add(new TreeBranchViewModel(child as TreeBranch, _governor));
                        else if (child is TreeLeaf)
                            Children.Add(new TreeLeafViewModel(child as TreeLeaf, _governor));
                    }
                }
            }
        }

        #endregion
    }

    class TreeLeafViewModel : TreeItemViewModel
    {
        readonly TreeLeaf _modelLeaf;

        public TreeLeafViewModel(TreeLeaf branch, iTreeViewModel governor)
            : this(branch, null, governor)
        {
        }

        private TreeLeafViewModel(TreeLeaf leaf, TreeBranchViewModel parent, iTreeViewModel governor)
            : base(leaf, parent, governor)
        {
            _modelLeaf = leaf;
        }

        public new bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                    _governor.CurrentImageFullpath = Fullpath;
                }
            }
        }
    }
}
