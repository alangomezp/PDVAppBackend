using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Services.Definition
{
    public interface IStudentServices
    {
        Result Register(StudentFactory student);
        Result Update(Guid id, StudentEdited studentEdited);
        Result Delete(Guid id);
    }
}
