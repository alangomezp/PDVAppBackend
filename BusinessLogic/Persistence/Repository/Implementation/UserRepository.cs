using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Persistence.Repository.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Implementation
{
    public class UserRepository : RepositoryServices<User>, IUserRepository
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext context): base(context) 
        {
            _db = context;
        }

        public User FindByEmail(string email) => 
            Find().Where(a => a.Email == email).SingleOrDefault();

        public User FindByCredentials(string username, string password) =>
            Find().Where(a => a.UserName == username && a.Password == password).SingleOrDefault();
    }
}
