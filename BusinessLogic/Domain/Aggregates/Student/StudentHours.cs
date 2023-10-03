using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class StudentHours
    {
        public Guid Id { get; set; }
        public int FundHours { get; set;}
        public Guid StudentId { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public StudentHours()
        {
            
        }

        public StudentHours(int hoursQty, Guid studentId)
        {
            Id = Guid.NewGuid();
            FundHours = hoursQty;
            StudentId = studentId;
            LastUpdatedDate = DateTime.Now;
        }

        public void Modify(int hours)
        {
            FundHours = hours;
            LastUpdatedDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
