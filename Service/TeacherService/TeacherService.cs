using Domain;
using Infrastructure.Repository;
using Service.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public TeacherForResultDto CreateTeacher(TeacherForCreationDto dto)
        {
            var studentAll = _teacherRepository.GetAll().Where(teacher => teacher.Email == dto.Email || teacher.PhoneNumber == dto.PhoneNumber).FirstOrDefault();
            if (studentAll != null)
                throw new Exception("Bu foydalaunvchi mavjud");

            var teacherdto = new Teacher()
            {
                Age = dto.Age,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Name = dto.Name,
                Login = dto.Login,
                Password = dto.Password,
            };
            var createsStudent = _teacherRepository.Create(teacherdto);

            return new TeacherForResultDto
            {
                Id = createsStudent.Id,
                Age = createsStudent.Age,
                Name = createsStudent.Name,
                Email = createsStudent.Email,
                PhoneNumber = createsStudent.PhoneNumber,
                Gender = createsStudent.Gender
            };
        }

        public void DeleteTeacher(int id)
        {
            var teacherId = _teacherRepository.Get(id);
            if (teacherId == null)
            {
                    throw new Exception("bu foydalanuvchi mavjud emas");
            }

            _teacherRepository.Delete(id);

        }

        public TeacherForResultDto Get(int id)
        {
            var result = _teacherRepository.Get(id);
            if (result == null)
            {
                throw new Exception("Bu foydalanuvchi mavjud emas");
            }
            return new TeacherForResultDto()
            {
                Id = result.Id,
                Age = result.Age,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Gender = result.Gender,
                Name = result.Name
            };
        }

        public IEnumerable<TeacherForResultDto> GetAll()
        {
            var GetAllresult = _teacherRepository.GetAll().Select(teacher => new TeacherForResultDto
            {
                Id = teacher.Id,
                Age = teacher.Age,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Gender = teacher.Gender,
                Name = teacher.Name
            }).AsEnumerable();
            if (GetAllresult == null)
                throw new Exception("Bu foydalanuchi mavjud emas ");

            return GetAllresult;
        }

        public TeacherForResultDto UpdeteTeacher(int id, TeacherForUpdateDto dto)
        {
            var teacherId = _teacherRepository.Get(id);
            if (teacherId == null)
            {
                throw new Exception("bu foydalanuvchi mavjud emas");
            }

            teacherId.Age = dto.Age;
            teacherId.Name = dto.Name;
            teacherId.Gender = dto.Gender;

            var result = _teacherRepository.Update(teacherId);

            return new TeacherForResultDto()
            {
                Id = result.Id,
                Age = result.Age,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Gender = result.Gender,
                Name = result.Name
            };
        }
    }
}
