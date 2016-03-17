using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    [Serializable]
    public class User
    {
        public string Login;
        public string Password;

        public User(string argLogin, string argPassword)
        {
            Login = argLogin;
            Password = argPassword;
        }
    }
}
