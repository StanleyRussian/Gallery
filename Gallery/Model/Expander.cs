using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    //The purpose of this class is to serve as mediator between any TreeBranch object in tree structure and governing iTree implementation
    //The iTree implementation(LocalTree in this case) should only subscribe to this one object and will get event notification about any node expanded
    class Expander
    {
        public delegate void TreeBranchDelegate(TreeBranch argBranch);
        public event TreeBranchDelegate NodeExpanded;

        private static Expander instance;

        private Expander() { }

        public void Expand(TreeBranch argBranch)
        {
            instance.NodeExpanded(argBranch);
        }

        public static Expander GetInstance()
        {
            if (instance == null)
                instance = new Expander();
            return instance;
        }
    }
}
