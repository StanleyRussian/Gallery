using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Gallery
{
    interface iGalleryViewModel
    {
        ObservableCollection<ImageViewModel> Images { get; }

        ICommand cmdAddToGallery
        { get; }

        void OnClose(object sender, CancelEventArgs e);
        void RemoveImage(string argFullpath);
    }
}