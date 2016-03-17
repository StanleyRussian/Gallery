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
    /// Interaction logic for controlSignup.xaml
    /// </summary>
    public partial class controlSignup : UserControl
    {
        UserDatabase _db;
        LoginWindow _parent;

        public controlSignup(UserDatabase argDB, LoginWindow argParent)
        {
            _db = argDB;
            _parent = argParent;
            InitializeComponent();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            if (textboxPassword.Text == textboxConfirm.Text)
            {
                if (_db.Add(textboxLogin.Text, textboxPassword.Text))
                {
                    _parent.LoggedUser = _db.Get(textboxLogin.Text, textboxPassword.Text);
                    _parent.Close();
                }
                else
                    MessageBox.Show("User with such login already exists");
            }
            else
                MessageBox.Show("Passwords don't match");
        }
    }
}
