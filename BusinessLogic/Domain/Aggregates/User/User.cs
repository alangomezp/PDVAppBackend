using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class User: AggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }

        public User(UserFactory userFactory)
        {
            UserName = userFactory.UserName;
            Password = userFactory.Password;
            FirstName = userFactory.FirstName;
            LastName = userFactory.LastName;
            Email = userFactory.Email;

            Initialize();
        }

        private void Modify(UserEdited userEdit)
        {
            Email = userEdit.Email;
            UserName = userEdit.UserName;
            Password = userEdit.Password;
        }

    }
}
