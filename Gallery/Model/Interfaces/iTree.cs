﻿using System;
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
        TreeBranch Trunk { get; }

        void Expand(string name);
    }
}