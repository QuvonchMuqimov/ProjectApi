using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Teacher
{
    public class TeacherForUpdateDto
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
    }
}
