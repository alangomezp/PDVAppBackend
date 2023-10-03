using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class BagFund : AggregateRoot
    {
        public int Hours { get; private set; }
        public string MonthPeriod { get; private set; }
        public int YearPeriod { get; private set; }
        public Guid StudentId { get; private set; }

        public BagFund()
        {
            
        }

        public BagFund(BagFundFactory bagFundFactory)
        {
            Initialize();

            Hours = bagFundFactory.Hours;
            MonthPeriod = bagFundFactory.MonthPeriod;
            YearPeriod = bagFundFactory.YearPeriod;
            StudentId = bagFundFactory.StudentId;
        }

        public void Modify(BagFundEdited bagFundEdited)
        {
            if (bagFundEdited != null)
            {
                Hours = bagFundEdited.Hours;
                MonthPeriod = bagFundEdited.MonthPeriod;
                YearPeriod = bagFundEdited.YearPeriod;
                LastUpdatedDate = DateTime.Now;
            }
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}
