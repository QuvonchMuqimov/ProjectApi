using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Student;
using Service.StudentService;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]

        public IActionResult CreateStudent(StudentForCreationDto dto)
        {
            var response = _studentService.CreateStudent(dto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_studentService.Get(id));
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromRoute] int id, StudentForUpdateDto dto)
        {
            var response = _studentService.UpdateStudent(id, dto);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
