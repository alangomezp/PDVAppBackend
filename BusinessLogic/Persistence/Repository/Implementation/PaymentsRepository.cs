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
    public class PaymentsRepository : RepositoryServices<Payments>, IPaymentsRepository
    {
        private readonly DatabaseContext _db;

        public PaymentsRepository(DatabaseContext context): base(context) 
        {
            _db = context;
        }

        public IList<Payments> GetAll() =>
            Find().Where(a => a.IsDeleted == false).ToList();

    }
}
