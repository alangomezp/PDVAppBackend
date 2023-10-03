using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class FundAccount: AggregateRoot
    {
        public string Description { get; private set; }
        public string Owner { get; private set; }

        public FundAccount(string description, string owner)
        {
            Initialize();
            Description = description;
            Owner = owner;
        }
        public FundAccount() { }

    }
}
