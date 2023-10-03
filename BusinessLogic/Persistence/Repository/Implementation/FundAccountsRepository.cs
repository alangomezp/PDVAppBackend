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
    public class FundAccountsRepository : RepositoryServices<FundAccount>, IFundAccountsRepository
    {
        private readonly DatabaseContext _db;

        public FundAccountsRepository(DatabaseContext context): base(context) 
        {
            _db = context;
        }

        public IList<FundAccount> GetAll() =>
            Find().Where(a => a.IsDeleted == false).ToList();

        public FundAccount FindByDescription(string description) =>
            Find().Where(a => a.Description == description).SingleOrDefault();
    }
}
