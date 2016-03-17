using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Controls.controlLogin ctrlLogin;
        Controls.controlSignup ctrlSignup;
        LoginForm.UserDatabase UserDB;

        public User LoggedUser
        { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            UserDB = new LoginForm.UserDatabase();
            ctrlLogin = new Controls.controlLogin(UserDB, this);
            ctrlSignup = new Controls.controlSignup(UserDB, this);
            radioLogIn.IsChecked = true;
        }

        private void RadioLogin_Checked(object sender, RoutedEventArgs e)
        {
            LoginWindowContent.Content = ctrlLogin;
        }

        private void RadioSignup_Checked(object sender, RoutedEventArgs e)
        {
            LoginWindowContent.Content = ctrlSignup;
        }
    }
}
