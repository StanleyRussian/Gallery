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
        public iTree Parent
        { get; private set; }

        public string Name
        { get; private set; }

        public string Fullpath
        { get; private set; }

        public TreeItem(string name, string path, iTree parent)
        {
            Name = name;
            Fullpath = path;
            Parent = parent;
        }
    }

    // Expandable "Branch" item with Children property
    class TreeBranch : TreeItem
    {
        public List<TreeItem> Children
        { get; private set; }

        public TreeBranch(string name, string path, iTree parent)
            :base (name, path, parent)
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

        // This method is called from corresponding TreeBranchViewModel object when user expands a node in tree view
        public void Expand()
        {
            Parent.ExpandNode(this);
        }
    }

    // Closed "Leaf" item
    class TreeLeaf: TreeItem
    {
        public TreeLeaf(string name, string path, iTree parent)
            :base (name, path, parent)
        { }
    }
}
