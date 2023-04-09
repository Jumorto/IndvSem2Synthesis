using System;

namespace Models
{
    public class User
    {
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }

        private int _usertype;
        public int Usertype { get { return _usertype; } set { _usertype = value; } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; } }
        

        public User()
        {
            this.ID = 0;
            this.Usertype = 1;
        }
    }
}
