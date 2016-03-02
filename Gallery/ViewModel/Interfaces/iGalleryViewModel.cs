using System.Collections.ObjectModel;

namespace Gallery
{
    interface iGalleryViewModel
    {
        ObservableCollection<ImageViewModel> Images { get; }

        void Add(string path);
    }
}