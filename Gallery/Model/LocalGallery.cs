using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Class for an object which actually store list of images in List of iGalleryImage objects
    class LocalGallery : iGallery
    {
        public List<iGalleryImage> Images
        { get; set; }
    }
}
