using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace Gallery
{
    class ImageViewModel: INotifyPropertyChanged, iImageModel
    {
        private iImageModel _modelImage;
        private iGalleryViewModel _governor;

        public ImageViewModel(iImageModel argImage, iGalleryViewModel argGovernor )
        {
            _modelImage = argImage;
            _governor = argGovernor;

            cmdIncRating = new SimpleCommand(IncRating_Execute, IncRating_CanExecute);
            cmdDecRating = new SimpleCommand(DecRating_Execute, DecRating_CanExecute);
            cmdRemove = new SimpleCommand(Remove_Execute);
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
            set
            {
                _modelImage.Rating = value;
                OnPropertyChanged("Rating");
                cmdDecRating.CanExecute(null);
                cmdIncRating.CanExecute(null);
            }
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

        #region Commands

        public ICommand cmdIncRating
        { get; private set; }
        public ICommand cmdDecRating
        { get; private set; }
        public ICommand cmdRemove
        { get; private set; }

        private void Remove_Execute()
        {
            _governor.RemoveImage(_modelImage.Fullpath);
        }

        private void IncRating_Execute()
        {
            Rating++;
        }

        private bool IncRating_CanExecute(object arg)
        {
            if (Rating == 5)
                return false;
            else
                return true;
        }
        private void DecRating_Execute()
        {
            Rating--;
        }
        private bool DecRating_CanExecute(object arg)
        {
            if (Rating == 0)
                return false;
            else
                return true;
        }
        #endregion
    }
}
