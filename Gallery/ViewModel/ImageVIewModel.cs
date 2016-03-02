using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class ImageViewModel
    {
        readonly iGalleryImage ModelImage;

        public ImageViewModel(iGalleryImage image)
        {
            ModelImage = image;
        }

        public string Path
        {
            get { return ModelImage.Path; }
        }
    }
}
