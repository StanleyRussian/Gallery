using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Base abstract class for all elements in tree
    abstract class TreeItem
    {
        public string Name
        { get; private set; }

        public TreeItem(string name)
        {
            Name = name;
        }
    }
    
    // Expandable "Branch" item with Children property
    class TreeBranch: TreeItem
    {
        public List<TreeItem> Children
        { get; private set; }

        public TreeBranch(string name)
            :base (name)
        { }
    }

    // Closed "Leaf" item with Path property
    class TreeLeaf: TreeItem
    {
        public string Path
        { get; set; }

        public TreeLeaf(string name)
            :base (name)
        { }
    }
}
