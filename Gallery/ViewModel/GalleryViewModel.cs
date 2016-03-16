using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Gallery
{
    // ViewModel class for iGallery implementation
    class GalleryViewModel : iGalleryViewModel
    {
        readonly iGalleryModel _modelGallery;

        public ObservableCollection<ImageViewModel> Images
        { get; private set; }

        public GalleryViewModel(iGalleryModel gallery)
        {
            _modelGallery = gallery;
            Images = new ObservableCollection<ImageViewModel>();
            Refresh();

            cmdAddToGallery = new SimpleCommand(AddToGallery_Execute, param => AddToGallery_CanExecute());
        }

        private void Refresh()
        {
            Images.Clear();
            foreach (var image in _modelGallery.Images)
                Images.Add(new ImageViewModel(image));
        }

        #region Commands

        public ICommand cmdAddToGallery
        { get; private set; }

        private void AddToGallery_Execute(object argFullpath)
        {
            string Fullpath = argFullpath as string;
            if (Fullpath == "")
                return;
            _modelGallery.Add(Fullpath);
            Refresh();
        }

        private bool AddToGallery_CanExecute()
        {
            return true;
        }

        #endregion

        public void OnClose(object sender, CancelEventArgs e)
        {
            _modelGallery.SaveGallery();
        }
    }
}
