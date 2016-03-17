using Gallery.LoginForm;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallery.Controls
{
    /// <summary>
    /// Interaction logic for controlLogin.xaml
    /// </summary>
    public partial class controlLogin : UserControl
    {
        UserDatabase _db;
        LoginWindow _parent;

        public controlLogin(UserDatabase argDB, LoginWindow argParent)
        {
            _db = argDB;
            _parent = argParent;
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            User logged = _db.Get(textboxLogin.Text, textboxPassword.Password);
            if (logged != null) 
            {
                _parent.LoggedUser = logged;
                _parent.Close();
            }
            else
                MessageBox.Show("Login and/or password is invalid");
        }
    }
}
