using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gallery
{
    // ViewModel class for iTree implementation
    class TreeViewModel : iTreeViewModel, INotifyPropertyChanged
    {
        readonly iTreeModel _modelTree;

        public TreeViewModel(iTreeModel tree)
        {
            _modelTree = tree;
            Children = new ObservableCollection<TreeBranchViewModel>();
            foreach (var child in _modelTree.Children)
                Children.Add(new TreeBranchViewModel(child, this));
        }

        public ObservableCollection<TreeBranchViewModel> Children
        { get; private set; }

        private string currentImageFullpath;
        public string CurrentImageFullpath
        {
            get { return currentImageFullpath; }
            set
            {
                currentImageFullpath = value;
                OnPropertyChanged("CurrentImageFullpath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}