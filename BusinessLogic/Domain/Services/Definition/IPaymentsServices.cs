using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Definition
{
    public interface IPaymentsServices
    {
        Result Pay(PaymentFactory paymentFactory);
        Result Update(Guid id, PaymentEdited studentEdited);
        Result Delete(Guid id);
    }
}
