using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Interface for an obect representing gallery of images
    // GalleryViewModel (GalleryVM) adresses this interface
    interface iGallery
    {
        List<iGalleryImage> Images
        { get; }
    }
}
