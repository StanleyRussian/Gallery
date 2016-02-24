using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Model
{
    // Class representing entire tree with methods to fill it
    class FileTree: iTree
    {
        public TreeBranch Trunk
        { get; private set; }

        public FileTree()
        {
            Trunk = new TreeBranch("PC");
            string[] drives = Directory.GetLogicalDrives();
            foreach (var d in drives)
            {
                Trunk.Children.Add(new TreeBranch(Path.GetFileName(d)));
                RecursiveFillFolders(Trunk, d);
                FillPictures(Trunk, d);
            }
        }

        private void RecursiveFillFolders(TreeBranch parent, string directory)
        {
            string[] subfolders = Directory.GetDirectories(directory);
            foreach (var s in subfolders)
            {
                TreeBranch NewBranch = new TreeBranch(Path.GetFileName(s));
                parent.Children.Add(NewBranch);
                RecursiveFillFolders(NewBranch, s);
                FillPictures(NewBranch, s);
            }
        }

        private void FillPictures(TreeBranch parent, string directory)
        {
            string[] files = Directory.GetFiles(directory);
            foreach (var f in files)
            {
                if (Path.GetExtension(f) != ".png" ||
                    Path.GetExtension(f) != ".gif" ||
                    Path.GetExtension(f) != ".jpg" ||
                    Path.GetExtension(f) != ".bmp" ||
                    Path.GetExtension(f) != ".jpeg")
                    continue;
                TreeLeaf NewLeaf = new TreeLeaf(Path.GetFileName(f));
                NewLeaf.Path = f;
                parent.Children.Add(NewLeaf);
            }
        }
    }
}
