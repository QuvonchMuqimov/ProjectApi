using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Teacher;
using Service.TeacherService;
using System.Diagnostics.CodeAnalysis;

namespace ProjectApi.Controllers
{
        [ApiController]
        [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpPost]
        public IActionResult CreateTeacher(TeacherForCreationDto dto)
        {
            var responce = _teacherService.CreateTeacher(dto);
            return Ok(responce);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var responce = _teacherService.Get(id);
            return Ok(responce);
        }
        //public IActionResult GetAll()
        //{
        //    var responce = _teacherService.GetAll();
        //    return Ok(responce);
        //}
        [HttpPut("{id}")]
        public IActionResult TeacherUpdate([FromRoute]int id, TeacherForUpdateDto dto)
        {
            var responce = _teacherService.UpdeteTeacher(id, dto);
            return Ok(responce);    
        }
        [HttpDelete("{id}")]
        public void TeacherDelete(int id)
        {
            _teacherService.DeleteTeacher(id);
        }
    }
}
