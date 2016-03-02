using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // ViewModel class for iGallery implementation
    class GalleryViewModel : iGalleryViewModel
    {
        iGallery _gallery;

        public ObservableCollection<iGalleryImage> ImageList
        { get; private set; }

        public GalleryViewModel(iGallery gallery)
        {
            ImageList = new ObservableCollection<iGalleryImage>();
        }

        public void Add(string path)
        {
            throw new NotImplementedException();
        }
    }
}
