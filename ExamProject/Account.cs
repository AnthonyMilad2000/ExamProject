using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public Account(int id, string name, string password, string email, string phone, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;
            Role = role;
        }
        public bool login(Account account)
        {
            return this.Password == account.Password && this.Name == account.Name;
        }

    }

}
