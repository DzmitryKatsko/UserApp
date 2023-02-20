using MaterialDesignThemes.Wpf.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
     class User
    {
        public int id { get; set; }
        public string login, email, password;
        public string Login { get { return login; } private set { login = value; } }
        public string Email { get { return email; } private set { email = value; } }
        public string Password { get { return password; } private set { login = value; } }
        public User() { }
        public User(string login, string email, string password)
        {
            this.login = login;
            this.email = email;
            this.password = password;
        }

    }
}
