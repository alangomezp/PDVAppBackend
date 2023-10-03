using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class StudentFactory
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string ChurchName { get; set; }
        public bool HasBagFund { get; set; }
        public int HoursQty { get; set; } = 0;
        public DateTime AdmissionDate { get; set; }

       public StudentFactory(bool hasbagFund, DateTime admissionDate, string firstname, string lastname, string email, string phone, string nationality, string churchname, int hoursqty)
       {
            HasBagFund = hasbagFund;
            AdmissionDate = admissionDate;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
            Nationality = nationality;
            ChurchName = churchname;
            HoursQty = hoursqty;
       }

        public Student Create()
        {
            return new Student(this);
        }
    }
}
