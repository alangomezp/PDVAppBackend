using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Persistence.Repository.Definition;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Implementation
{
    public class StudentRepository : RepositoryServices<Student>, IStudentRepository
    {
        private readonly DatabaseContext _db;

        public StudentRepository(DatabaseContext context): base(context) 
        {
            _db = context;
        }

        public IList<Student> GetAll() =>
            Find().Include(a => a.fundHours).Where(a => a.IsDeleted == false).ToList();

        public Student FindByEmail(string email) =>
            Find().Where(a => a.Email == email).SingleOrDefault();

        public StudentHours getHours(Guid studentId) =>
            _db.StudentHours.Where(a => a.StudentId == studentId && a.IsDeleted == false).SingleOrDefault();
    }
}
