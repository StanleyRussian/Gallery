using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Implementation of iTree for local images
    // Class representing entire tree with methods to manage it

    /*
     * Tree logic:
     * Tree starts with all drives visible to user as roots, actual root is hidden
     * All drives also filled with their subfolders to properly display expand button
     * When user expands node Expand() method is invoked
     * It add all images to expanded node
     * And since node already contains it's subfolders, Expand() method adds subfolders to subfolders instead
     */
    class LocalTree: iTree
    {
        public TreeBranch Trunk
        { get; private set; }

        /* In constructor:
         * Create branch for each found drive and add it to root
         * Create branch for each folder in each drive and add them to corresponding drives
         */
        public LocalTree()
        {
            Trunk = new TreeBranch("PC", "");
            string[] drives = Directory.GetLogicalDrives();
            foreach (var d in drives)
            {
                TreeBranch Drive = new TreeBranch(Path.GetFileName(d), d);
                Trunk.Children.Add(Drive);
                AddFoldersTo(Drive);
            }
        }

        // Method finding all subfolders in corresponing folder of given TreeBranch and adding them as new TreeBranch
        private void AddFoldersTo (TreeBranch root)
        {
            string[] folders = Directory.GetDirectories(root.Fullpath);
            Parallel.ForEach(folders, (f) =>
            {
                root.Children.Add(new TreeBranch(Path.GetFileName(f), f));
            });
            //foreach (var f in folders)
            //    root.Children.Add(new TreeBranch(Path.GetFileName(f), f));
            root.Children.Sort();
        }

        // Method finding all images in corresponing folder of given TreeBranch and adding them as new TreeLeaf
        private void AddImagesTo(TreeBranch root)
        {
            string[] files = Directory.GetFiles(root.Fullpath);
            foreach (var f in files)
            {
                if (Path.GetExtension(f) != ".png" ||
                    Path.GetExtension(f) != ".gif" ||
                    Path.GetExtension(f) != ".jpg" ||
                    Path.GetExtension(f) != ".bmp" ||
                    Path.GetExtension(f) != ".jpeg")
                    continue;
                TreeLeaf NewLeaf = new TreeLeaf(Path.GetFileName(f), f);
            }
        }

        // This method adds all images to expanded node
        // And since node already contains it's subfolders, id adds subfolders to subfolders
        public void Expand(string name)
        {
            TreeBranch ExpandedNode = Trunk.Find(name, true) as TreeBranch;
            AddImagesTo(ExpandedNode);
            foreach (TreeBranch child in ExpandedNode.Children)
                AddFoldersTo(child);
        }
    }
}
