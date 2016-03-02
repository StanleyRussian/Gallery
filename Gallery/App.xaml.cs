using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            iGallery GalleryM = new LocalGallery();
            iTree TreeM = new LocalTree();

            GalleryViewModel GalleryVM = new GalleryViewModel(GalleryM);
            TreeViewModel TreeVM = new TreeViewModel(TreeM);

            MainWindow MainW = new MainWindow(GalleryVM, TreeVM);
            MainW.Show();
        }
    }
}
