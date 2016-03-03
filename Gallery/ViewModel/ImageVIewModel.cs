using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class ImageViewModel: INotifyPropertyChanged, iGalleryImage
    {
        readonly iGalleryImage _modelImage;

        public ImageViewModel(iGalleryImage image)
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

        public int Mark
        {
            get { return _modelImage.Mark; }
        }

        public string Path
        {
            get { return _modelImage.Path; }
        }

        public long Size
        {
            get { return _modelImage.Size; }
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
