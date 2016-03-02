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
        readonly iGallery _modelGallery;

        public ObservableCollection<ImageViewModel> Images
        { get; private set; }

        public GalleryViewModel(iGallery gallery)
        {
            _modelGallery = gallery;
            Images = new ObservableCollection<ImageViewModel>();
            foreach (var image in _modelGallery.Images)
                Images.Add(new ImageViewModel(image));
        }

        public void Add(string path)
        {
            throw new NotImplementedException();
        }
    }
}
