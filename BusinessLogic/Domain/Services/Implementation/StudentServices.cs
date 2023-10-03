using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Persistence.Repository.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Implementation
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRepositoryServices<Student> _repositoryServices;

        public StudentServices(IStudentRepository studentRepository, IRepositoryServices<Student> repositoryServices)
        {
            _studentRepository = studentRepository;
            _repositoryServices = repositoryServices;

        }
        public Result Register(StudentFactory studentFactory)
        {
            var isCreated = _studentRepository.FindByEmail(studentFactory.Email);

            if (isCreated != null)
                return Result.Failed("Este usuario ya ha existe");
            try
            {
                var student = studentFactory.Create();
                _repositoryServices.Insert(student);
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Usuario creado");
        }

        public Result Update(Guid id, StudentEdited studentEdited) 
        {
            var student = _repositoryServices.FindById(id);

            if (student == null)
                return Result.Failed("Este usuario no existe");

            try
            {
                student.Modify(studentEdited);
                if (studentEdited.HasBagFund && studentEdited.HoursQty != 0)
                {
                    var studentHours = _studentRepository.getHours(student.Id);
                    if (studentHours == null)
                    {
                        studentHours = new StudentHours(studentEdited.HoursQty, id);
                    }
                    studentHours.Modify(studentEdited.HoursQty);
                }

                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);

            }

            return Result.Succeed("Usuario modificado");

        }

        public Result Delete(Guid id)
        {
            var student = _repositoryServices.FindById(id);

            if (student == null)
                return Result.Failed("No existe");

            try
            {
                student.Delete();
                _repositoryServices.Save();
            }
            catch (Exception ex)
            {
                return Result.Failed(ex.Message);
            }

            return Result.Succeed("Borrado correctamente");

        }

    }
}
