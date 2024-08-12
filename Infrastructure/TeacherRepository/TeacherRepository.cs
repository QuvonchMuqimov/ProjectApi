using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDbConxext _context;
        public TeacherRepository(MyDbConxext conxext)
        {
            _context = conxext;
        }
        public Teacher Create(Teacher teacher)
        {
          var createTeacher = _context.Teacher.Add(teacher);
          _context.SaveChanges();
            return createTeacher.Entity;
        }

        public void Delete(int id)
        {
            var teacher = _context.Teacher.FirstOrDefault(a=>a.Id == id);
            if(teacher is null)
            {
                throw new Exception("Student topilmadi");
            }
            _context.Teacher.Remove(teacher);
            _context.SaveChanges();
        }

        public Teacher Get(int id)
        {
            var teacher = _context.Teacher.Where(a=>a.Id == id).FirstOrDefault();
            return teacher;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teacher.AsEnumerable();
        }

        public Teacher Update(Teacher teacher)
        {
            var teacherUpdate = _context.Teacher.Update(teacher);
            _context.SaveChanges();
            return teacherUpdate.Entity;
        }
    }
}
