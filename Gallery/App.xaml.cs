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
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            LoginWindow LoginW = new LoginWindow();
            LoginW.ShowDialog();
            if (LoginW.LoggedUser == null)
                Shutdown();
            else
                ShutdownMode = ShutdownMode.OnLastWindowClose;

            iGalleryModel GalleryM = new LocalGallery(LoginW.LoggedUser);
            iTreeModel TreeM = new LocalTree();

            iGalleryViewModel GalleryVM = new GalleryViewModel(GalleryM);
            iTreeViewModel TreeVM = new TreeViewModel(TreeM);

            MainWindow MainW = new MainWindow(GalleryVM, TreeVM);
            MainW.Show();
        }
    }
}
