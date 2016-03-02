using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class ImageViewModel: iGalleryImage
    {
        readonly iGalleryImage ModelImage;

        public ImageViewModel(iGalleryImage image)
        {
            ModelImage = image;
        }

        public DateTime Added
        {
            get { return ModelImage.Added; }
        }

        public string Contributor
        {
            get { return ModelImage.Contributor; }
        }

        public int Mark
        {
            get { return ModelImage.Mark; }
        }

        public string Path
        {
            get { return ModelImage.Path; }
        }

        public int Size
        {
            get { return ModelImage.Size; }
        }
    }
}
