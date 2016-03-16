using System.Collections.Generic;

namespace Gallery
{
    // Interface for an object who represent the entire filetree
    // TreeViewModel (TreeVM) adresses this interface
    interface iTreeModel
    {
        List<TreeBranch> Children { get; }

        void ExpandNode(TreeBranch argBranch);
    }
}
