using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class PaymentEdited
    {
        public Guid StudentId { get; set; }
        public Guid FundAccountId { get; set; }
        public decimal Amount { get; set; }
        public string ModifiedBy { get; set; }

    }
}
