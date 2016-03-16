using System.Collections.Generic;

namespace Gallery
{
    // Base abstract class for all elements in tree
    abstract class TreeItem
    {
        protected readonly iTreeModel _governor;

        public string Name
        { get; private set; }

        public string Fullpath
        { get; private set; }

        public TreeItem(string name, string path, iTreeModel governor)
        {
            Name = name;
            Fullpath = path;
            _governor = governor;
        }
    }

    // Expandable "Branch" item with Children property
    class TreeBranch : TreeItem
    {
        public List<TreeItem> Children
        { get; private set; }

        public TreeBranch(string name, string path, iTreeModel parent)
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
            _governor.ExpandNode(this);
        }
    }

    // Closed "Leaf" item
    class TreeLeaf: TreeItem
    {
        public TreeLeaf(string name, string path, iTreeModel parent)
            :base (name, path, parent)
        { }
    }
}
