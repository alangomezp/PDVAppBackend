using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Definition
{
    public interface IBagFundServices
    {
        Result Register(BagFundFactory bagFundFactory);
        Result Update(Guid id, BagFundEdited bagFundEdited);
        Result Delete(Guid id);
    }
}
