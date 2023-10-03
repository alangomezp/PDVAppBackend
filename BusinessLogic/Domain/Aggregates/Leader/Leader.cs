using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Domain.Core;

namespace BusinessLogic.Domain.Aggregates
{
    public class Leader: AggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ChurchName { get; set; }
        public Leader() { }
    }
}
