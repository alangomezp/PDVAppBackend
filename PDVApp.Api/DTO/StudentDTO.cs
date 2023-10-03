using BusinessLogic.Domain.Aggregates;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PDVApp.Api.DTO
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string ChurchName { get; set; }
        public bool HasBagFund { get; set; }
        public int? HoursQty { get; set; }
        public DateTime AdmissionDate {  get; set; }

        public static List<StudentDTO> Parse (IList<Student> student)
        {
            List<StudentDTO> list = new List<StudentDTO>();

            foreach (var item in student)
            {
                list.Add(
                    new StudentDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.Phone,
                        Nationality = item.Nationality,
                        ChurchName = item.ChurchName,
                        HasBagFund = item.HasBagFund,
                        HoursQty = item.fundHours?.FundHours,
                        AdmissionDate = item.AdmissionDate
                    });
            }

            return list;
        }
    }
}
