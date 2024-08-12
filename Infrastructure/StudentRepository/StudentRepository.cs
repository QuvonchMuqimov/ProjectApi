using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly MyDbConxext _context;
    public StudentRepository(MyDbConxext context)
    {
        _context = context;
    }

    public Student Create(Student student)
    
    {
        var ceatedStudent = _context.Student.Add(student);
        _context.SaveChanges();
        return ceatedStudent.Entity;
    }

    public void Delete(int id)
    {
        var student = _context.Student.FirstOrDefault(x => x.Id == id);
        if (student is null)
        {
            throw new Exception("Student topilmadi");
        }

        _context.Student.Remove(student);
        _context.SaveChanges();

    }

    public Student Get(int id)
    {
        var student = _context.Student.FirstOrDefault(x => x.Id == id);

        return student;
    }

    public IEnumerable<Student> GetAll()
    {
        return _context.Student.AsEnumerable();
    }

    public Student Update(Student student)
    {
        var updatedStudent = _context.Student.Update(student);
        _context.SaveChanges();

        return updatedStudent.Entity;
    }

}
