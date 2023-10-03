using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class Payments: AggregateRoot
    {
        public Guid StudentId { get; private set; }
        public Guid FundAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; } = string.Empty;

        public Payments()
        {
            
        }

        public Payments(PaymentFactory paymentFactory) 
        {
            Initialize();

            StudentId = paymentFactory.StudentId;
            FundAccountId = paymentFactory.FundAccountId;
            Amount = paymentFactory.Amount;
            CreatedBy = paymentFactory.CreatedBy;
        }

        public void Modify(PaymentEdited paymentEdited)
        {
            if (paymentEdited != null)
            {
                StudentId = paymentEdited.StudentId;
                FundAccountId = paymentEdited.FundAccountId;
                Amount = paymentEdited.Amount;
                ModifiedBy = paymentEdited.ModifiedBy;
                LastUpdatedDate = DateTime.Now;
            }
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
