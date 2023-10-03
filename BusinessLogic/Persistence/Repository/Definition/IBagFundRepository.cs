using BusinessLogic.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Definition
{
    public interface IBagFundRepository
    {
        IList<BagFund> GetAll();
        IList<BagFund> GetByDate(DateTime from, DateTime to);
        decimal GetHoursValue();
    }
}
