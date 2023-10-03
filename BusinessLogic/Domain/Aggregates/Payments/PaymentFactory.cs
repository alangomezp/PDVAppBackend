using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class PaymentFactory
    {
        public Guid StudentId { get; set; }
        public Guid FundAccountId { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }

        public PaymentFactory(Guid studentId, Guid fundAccountId, decimal amount, string createdBy) 
        {
            StudentId = studentId;
            FundAccountId = fundAccountId;
            Amount = amount;
            CreatedBy = createdBy;
        }

        public Payments Create()
        {
            return new Payments(this);
        }
    }
}
