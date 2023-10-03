using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Core
{
    public class AggregateRoot
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public void Initialize()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
