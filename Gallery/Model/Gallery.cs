using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Class for an object which actually store list of images in List of iGalleryImage objects
    class Gallery : iGallery
    {
        public List<iGalleryImage> Images
        { get; set; }

        // Private implementation of iGalleryImage for local images
        // Made private for purpose that nobody can create this object externally
        private class LocalImage : iGalleryImage
        {
            public string Path { get; set; }
            public int Size { get; set; }
            public int Mark { get; set; }
            public string Contributor { get; set; }
            public DateTime Added { get; set; }

            LocalImage(string path)
            {
                Path = path;
                Added = new DateTime();
                Added = DateTime.Now;
            }
        }
    }
}
