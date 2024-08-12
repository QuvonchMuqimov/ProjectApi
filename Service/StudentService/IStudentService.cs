using Domain;
using Service.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StudentService
{
    public interface IStudentService 
    {
        StudentForResultDto Get(int id);
        IEnumerable<StudentForResultDto> GetAll();
        public StudentForResultDto CreateStudent(StudentForCreationDto dto);
        public StudentForResultDto UpdateStudent(int id, StudentForUpdateDto dto);
        public void DeleteStudent(int id);
    }
}
