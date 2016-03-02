using System;
using System.Collections.Generic;
using System.IO;
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

        public string Fullpath
        { get; private set; }

        public TreeItem(string name, string path)
        {
            Name = name;
            Fullpath = path;
        }
    }

    // Expandable "Branch" item with Children property
    class TreeBranch: TreeItem
    {
        public List<TreeItem> Children
        { get; private set; }

        public TreeBranch(string name, string path)
            :base (name, path)
        {
            Children = new List<TreeItem>();
        }

        // Method to find first occurence of TreeItem with given name
        // Second parameter define will children be searched or not
        public TreeItem Find(string name, bool searchChildren)
        {
            TreeItem found = Children.Find(x => x.Name == name);

            if (found == null && searchChildren)
                foreach (var child in Children)
                    if (child is TreeBranch)
                    {
                        TreeBranch childBranch = child as TreeBranch;
                        childBranch.Find(name, searchChildren);
                    }

            return found;
        }
    }

    // Closed "Leaf" item
    class TreeLeaf: TreeItem
    {
        public TreeLeaf(string name, string path)
            :base (name, path)
        { }
    }
}
