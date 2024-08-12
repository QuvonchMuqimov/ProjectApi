using Domain;

namespace Infrastructure.Repository;

public interface IStudentRepository
{
    Student Get(int id);
    IEnumerable<Student> GetAll();
    Student Update(Student student);
    Student Create(Student student);
    void Delete(int id);
}
