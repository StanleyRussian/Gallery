using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Interface for an object who represent the entire filetree
    // TreeViewModel (TreeVM) adresses this interface
    interface iTree
    {
        List<TreeBranch> Children { get; }

        void ExpandNode(string name);
    }
}
