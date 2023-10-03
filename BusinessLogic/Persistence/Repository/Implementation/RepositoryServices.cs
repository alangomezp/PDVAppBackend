using BusinessLogic.Domain.Core;
using BusinessLogic.Persistence.Repository.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Implementation
{
    public class RepositoryServices<T> : IRepositoryServices<T> where T : AggregateRoot
    {
        private readonly DatabaseContext _db;

        public RepositoryServices(DatabaseContext context)
        {
            _db = context;
        }

        public void Insert(T entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Save() =>
            _db.SaveChanges();

        public IQueryable<T> Find() =>
            _db.Set<T>();

        public T FindById(Guid id) =>
            _db.Set<T>().Where(a => a.Id == id).SingleOrDefault()!;

    }
}
