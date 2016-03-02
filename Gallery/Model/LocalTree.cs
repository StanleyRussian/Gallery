using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    /*
     * Tree logic:
     * Tree starts with all drives visible to user
     * All drives also filled with their subfolders to properly display expand button
     * When user expands node Expand() method is invoked
     * It add all images to expanded node
     * And since node already contains it's subfolders, Expand() method adds subfolders to subfolders instead
     */

    // Implementation of iTree for local images
    // Class representing entire tree with methods to manage it
    class LocalTree : iTree
    {
        public List<TreeBranch> Children
        { get; private set; }

        // In constructor:
        // Create branch for each found drive and add it to root
        // Create branch for each folder in each drive and add them to corresponding drives
        public LocalTree()
        {
            Children = new List<TreeBranch>();
            string[] drives = Directory.GetLogicalDrives();
            foreach (var d in drives)
            {
                TreeBranch Drive = new TreeBranch(d, d);
                Children.Add(Drive);
                AddFoldersTo(Drive);
            }
        }

        // Method finding all subfolders in corresponing folder of given TreeBranch and adding them as new TreeBranch
        private void AddFoldersTo (TreeBranch root)
        {
            try
            {
                string[] folders = Directory.GetDirectories(root.Fullpath);
                Parallel.ForEach(folders, (f) =>
                {
                    root.Children.Add(new TreeBranch(Path.GetFileName(f), f));
                });
            }
            catch (UnauthorizedAccessException) { }
            //foreach (var f in folders)
            //    root.Children.Add(new TreeBranch(Path.GetFileName(f), f));
            //root.Children.Sort();
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
            TreeBranch ExpandedNode = null;
            foreach (var drive in Children)
            {
                ExpandedNode = drive.Find(name, true) as TreeBranch;
                if (ExpandedNode != null)
                    break;
            }

            AddImagesTo(ExpandedNode);
            foreach (TreeBranch child in ExpandedNode.Children)
                AddFoldersTo(child);
        }
    }
}
