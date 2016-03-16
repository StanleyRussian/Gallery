using System;
using System.ComponentModel;
using System.IO;

namespace Gallery
{
    class ImageViewModel: INotifyPropertyChanged, iImageModel
    {
        readonly iImageModel _modelImage;

        public ImageViewModel(iImageModel image)
        {
            _modelImage = image;
        }

        #region Model Properties (iGalleryImage implementation)

        public DateTime Added
        {
            get { return _modelImage.Added; }
        }

        public string Contributor
        {
            get { return _modelImage.Contributor; }
        }

        public int Rating
        {
            get { return _modelImage.Rating; }
            set { _modelImage.Rating = value; }
        }

        public string Fullpath
        {
            get { return _modelImage.Fullpath; }
        }

        public string Name
        {
            get { return Path.GetFileName(_modelImage.Fullpath); }
        }

        public long Size
        {
            get { return _modelImage.Size; }
        }

        public long SizeKb
        {
            get { return _modelImage.Size / 1024; }
        }

        #endregion

        #region UI Properties and INotifyPropertyChanged implementation

        private bool _isSelected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
