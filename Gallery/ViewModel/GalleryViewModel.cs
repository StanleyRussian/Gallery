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
        iGallery GalleryModel;

        public ObservableCollection<ImageViewModel> ImageList
        { get; private set; }

        public GalleryViewModel(iGallery gallery)
        {
            GalleryModel = gallery;
            ImageList = new ObservableCollection<ImageViewModel>();
            foreach (var image in GalleryModel.Images)
                ImageList.Add(new ImageViewModel(image));
        }

        public void Add(string path)
        {
            throw new NotImplementedException();
        }
    }
}
