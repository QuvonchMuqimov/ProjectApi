using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface ITeacherRepository
    {
        Teacher Get(int id);
        IEnumerable<Teacher> GetAll();
        Teacher Create(Teacher teacher);
        Teacher Update(Teacher teacher);
        void Delete(int id);

    }
}
