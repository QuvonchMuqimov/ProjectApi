using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Service.DTOs.Student;
using Service.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentForResultDto CreateStudent(StudentForCreationDto dto)
        {
            var student = _studentRepository.GetAll().Where(a => a.Email == dto.Email || a.PhoneNumber == dto.PhoneNumber).FirstOrDefault();
            if (student != null)
                throw new Exception("Bu Foydalanuvchi mavjud");

            var data = new Student()
            {
                Age = dto.Age,
                Email = dto.Email,
                Gender = dto.Gender,
                Login = dto.Login,
                Name = dto.Name,
                Password = dto.Password,
                PhoneNumber = dto.PhoneNumber,
            };

            var createdData = _studentRepository.Create(data);


            return new StudentForResultDto()
            {
                PhoneNumber = createdData.PhoneNumber,
                Name = createdData.Name,
                Age = createdData.Age,
                Email = createdData.Email,
                Gender = createdData.Gender,
            };
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.Get(id);
            if (student == null)
            {
                throw new Exception("Bu foydalanuvchi mavjud emas");

            }
             _studentRepository.Delete(id);
        }

        public StudentForResultDto Get(int id)
        {
            var student = _studentRepository.Get(id);
            if (student == null)
            {
                throw new UniversalException(404, "Student mavjud emas");
            }

            return new StudentForResultDto
            {
                Age = student.Age,
                Email = student.Email,
                Gender = student.Gender,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                Id = student.Id

            };
        }

        public IEnumerable<StudentForResultDto> GetAll()
        {
            var result = _studentRepository.GetAll().Select(e => new StudentForResultDto
            {
                Age = e.Age,
                Email = e.Email,
                Gender = e.Gender,
                Name = e.Name,
                PhoneNumber = e.PhoneNumber,
            }).AsEnumerable();
            
            if (result == null)
                throw new Exception("malumot topilmadi");
         
            return result;
        }


        public StudentForResultDto UpdateStudent(int id, StudentForUpdateDto dto)
        {
            var getUser = _studentRepository.Get(id);

            getUser.Name = dto.Name;
            getUser.Age = dto.Age;
            getUser.Gender = dto.Gender;

            var updatedResult = _studentRepository.Update(getUser);

            return new StudentForResultDto()
            {
                Age = updatedResult.Age,
                Name = updatedResult.Name,
                Gender = updatedResult.Gender,
                Email = updatedResult.Email,
                PhoneNumber = updatedResult.PhoneNumber,
            };
            
            }
    }
}

