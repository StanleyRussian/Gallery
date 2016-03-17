using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.LoginForm
{
    public class UserDatabase
    {
        private List<User> UserList;
        readonly private string _savepath;

        public UserDatabase()
        {
            UserList = new List<User>();
            _savepath = "db";
            Load();
        }

        public bool Contains(string argLogin, string argPassword)
        {
            if (UserList.Exists(x => x.Login == argLogin && x.Password == argPassword))
                return true;
            else
                return false;
        }

        public bool Add(string argLogin, string argPassword)
        {
            if (UserList.Exists(x => x.Login == argLogin))
                return false;
            else
            {
                UserList.Add(new User(argLogin, argPassword));
                Save();
                return true;
            }
        }

        public User Get(string argLogin, string argPassword)
        {
            return UserList.Find(x => x.Login == argLogin && x.Password == argPassword);
        }

        private void Save()
        {
            FileStream stream = new FileStream(_savepath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, UserList);
            stream.Close();
        }

        private void Load()
        {
            if (!File.Exists(_savepath))
                return;
            FileStream stream = new FileStream(_savepath, FileMode.Open);
            if (stream.Length == 0)
                return;
            BinaryFormatter formatter = new BinaryFormatter();
            UserList = (List<User>)formatter.Deserialize(stream);
            stream.Close();

        }
    }
}
