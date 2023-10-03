using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class UserFactory
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserFactory(string username, string password, string firstname, string lastname, string email)
        {
            UserName = username;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }

        public User Create()
        {
            return new User(this);
        }
    }
}
