using BusinessLogic.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Repository.Definition
{
    public interface IFundAccountsRepository
    {
        FundAccount FindByDescription(string description);
    }
}
