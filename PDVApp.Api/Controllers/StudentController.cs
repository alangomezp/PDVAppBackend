using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Domain.Services.Implementation;
using BusinessLogic.Persistence.Repository.Definition;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PDVApp.Api.DTO;

namespace PDVApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<Student> _logger;
        private readonly IStudentServices _studentService;
        private readonly IStudentRepository _studentRepository;

        public StudentController(ILogger<Student> logger, IStudentServices studentService, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentService = studentService;
            _studentRepository = studentRepository;
        }

        [HttpGet(Name = "GetAllStudents")]
        public IList<StudentDTO> Get()
        {
            return StudentDTO.Parse(_studentRepository.GetAll());
        }

        [HttpPost(Name = "RegisterStudent")]
        public Result Post([FromBody] StudentFactory studentFactory)
        {
            return _studentService.Register(studentFactory);
        }

        [HttpPut(Name = "UpdateStudent")]
        public Result Put([FromQuery] string id, [FromBody] StudentEdited studentEdited)
        {
            Guid guid = Guid.Parse(id);
            return _studentService.Update(guid, studentEdited);
        }

        [HttpDelete(Name = "DeleteStudent")]
        public Result Delete([FromQuery] string id)
        {
            Guid guid = Guid.Parse(id);
            return _studentService.Delete(guid);
        }

    }
}