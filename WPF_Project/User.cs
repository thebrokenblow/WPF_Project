using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project
{
    class User
    {
        [Key]
        public int id { get; set; }
        private string login, password, email;

        public string Login {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public User() { }
        public User(string login, string password, string email) {
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}
