using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Implementation of iGalleryImage for local images
    class LocalImage : iGalleryImage
    {
        public string Path { get; private set; }
        public long Size { get; private set; }
        public string Contributor { get; private set; }
        public DateTime Added { get; private set; }

        public int Mark { get; set; }

        public LocalImage(string path)
        {
            Path = path;
            Added = new DateTime();
            Added = DateTime.Now;
            Size = new System.IO.FileInfo(path).Length;
        }
    }
}
