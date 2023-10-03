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
    public class BagFundRepository : RepositoryServices<BagFund>, IBagFundRepository
    {
        private readonly DatabaseContext _db;

        public BagFundRepository(DatabaseContext context): base(context) 
        {
            _db = context;
        }

        public IList<BagFund> GetAll() =>
            Find().Where(a => a.IsDeleted == false).ToList();

        public IList<BagFund> GetByDate(DateTime from, DateTime to) =>
            Find().Where(a => a.IsDeleted == false && a.CreatedDate >= from && a.CreatedDate <= to).ToList();

        public decimal GetHoursValue() =>
            _db.BagFundValue.SingleOrDefault()!.HourValue;
    }
}
