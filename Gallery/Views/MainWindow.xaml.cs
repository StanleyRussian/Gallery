using System.Windows;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private iGalleryViewModel GalleryVM;
        private iTreeViewModel TreeVM;

        internal MainWindow(iGalleryViewModel gallery, iTreeViewModel tree)
        {
            InitializeComponent();

            GalleryVM = gallery;
            listviewGallery.DataContext = GalleryVM;
            controlImage.DataContext = GalleryVM;
            TreeVM = tree;
            expandBrowser.DataContext = TreeVM;
            buttonAdd.DataContext = GalleryVM;

            Closing += GalleryVM.OnClose;
        }

        #region UI Behaviour

        private GridLength expandedHeight = new GridLength(0.5, GridUnitType.Star);

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            expanderRow.Height = expandedHeight;
            expander.Visibility = Visibility.Visible;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            expandedHeight = expanderRow.Height;
            expanderRow.Height = GridLength.Auto;
            expander.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}