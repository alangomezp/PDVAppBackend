using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Aggregates
{
    public class Student : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Nationality { get; private set; }
        public string ChurchName { get; private set; }
        public bool HasBagFund { get; private set; }
        public virtual StudentHours? fundHours { get; private set; }
        public DateTime AdmissionDate { get; private set; }

        public Student(StudentFactory factory)
        {
            Initialize();

            FirstName = factory.FirstName;
            LastName = factory.LastName;
            Email = factory.Email;
            Phone = factory.Phone;
            Nationality = factory.Nationality;
            ChurchName = factory.ChurchName;
            HasBagFund = factory.HasBagFund;
            AdmissionDate = factory.AdmissionDate;

            if (factory.HasBagFund == true && factory.HoursQty != 0)
                fundHours = new StudentHours(factory.HoursQty, Id);

        }

        public Student()
        {
            
        }

        public void Modify(StudentEdited studentEdit)
        {
            if(studentEdit != null)
            {
                FirstName = studentEdit.FirstName;
                LastName = studentEdit.LastName;
                Email = studentEdit.Email;
                Phone = studentEdit.Phone;
                HasBagFund = studentEdit.HasBagFund;

                LastUpdatedDate = DateTime.Now;
            }
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
