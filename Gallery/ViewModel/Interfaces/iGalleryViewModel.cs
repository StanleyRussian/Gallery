using System.Collections.ObjectModel;

namespace Gallery
{
    interface iGalleryViewModel
    {
        ObservableCollection<iGalleryImage> ImageList { get; }

        void Add(string path);
    }
}