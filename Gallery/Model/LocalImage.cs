using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Implementation of iGalleryImage for local images
    class LocalImage : iGalleryImage
    {
        public string Path { get; private set; }
        public int Size { get; private set; }
        public int Mark { get; set; }
        public string Contributor { get; private set; }
        public DateTime Added { get; private set; }

        LocalImage(string path)
        {
            Path = path;
            Added = new DateTime();
            Added = DateTime.Now;
        }
    }
}
