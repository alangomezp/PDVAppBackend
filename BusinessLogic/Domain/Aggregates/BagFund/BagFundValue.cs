using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class BagFundValue
    {
        public decimal HourValue { get; set; }

        public BagFundValue(decimal hoursValue)
        {
            HourValue = hoursValue;
        }
        public BagFundValue()
        {

        }
    }
}
