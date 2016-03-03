using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // ViewModel class for iTree implementation
    class TreeViewModel : iTreeViewModel, INotifyPropertyChanged
    {
        readonly iTree _modelTree;

        public TreeViewModel(iTree tree)
        {
            _modelTree = tree;
            Children = new ObservableCollection<TreeBranchViewModel>();
            foreach (var child in _modelTree.Children)
                Children.Add(new TreeBranchViewModel(child));
        }

        public ObservableCollection<TreeBranchViewModel> Children
        { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void ExpandNode(string name)
        {
            _modelTree.ExpandNode(name);
        }
    }
}