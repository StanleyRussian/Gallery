using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // ViewModel class for iGallery implementation
    class GalleryVM
    {
        iGallery _gallery;

        public List<iGalleryImage> Images
        {
            get
            { return _gallery.Images; }
        }

        public GalleryVM(iGallery gallery)
        {
            _gallery = gallery;
        }
    }
}
