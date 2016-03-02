using System.Collections.ObjectModel;

namespace Gallery
{
    interface iGalleryViewModel
    {
        ObservableCollection<ImageViewModel> ImageList { get; }

        void Add(string path);
    }
}