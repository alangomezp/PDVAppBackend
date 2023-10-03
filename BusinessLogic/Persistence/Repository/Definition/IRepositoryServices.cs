using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Definition
{
    public interface IRepositoryServices<T> where T : AggregateRoot
    {
        void Insert(T entity);
        T FindById(Guid id);
        IQueryable<T> Find();
        void Save();
    }
}
