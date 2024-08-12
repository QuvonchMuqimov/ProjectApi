using Infrastructure.Repository;
using Service.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TeacherService
{
    public interface ITeacherService 
    {
        TeacherForResultDto Get(int id);
        IEnumerable<TeacherForResultDto> GetAll();
        TeacherForResultDto CreateTeacher(TeacherForCreationDto dto);
        TeacherForResultDto UpdeteTeacher(int id,TeacherForUpdateDto dto);
        void DeleteTeacher(int id);


    }
}
