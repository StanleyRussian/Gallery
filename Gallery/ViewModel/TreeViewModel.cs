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
        iTree _tree;

        public TreeViewModel(iTree tree)
        {
            Children = new ObservableCollection<TreeBranchViewModel>(
                new TreeBranchViewModel[]
                {
                    tree.Children
                });
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
            _tree.Expand(name);
            OnPropertyChanged("Branches");
        }
    }
}