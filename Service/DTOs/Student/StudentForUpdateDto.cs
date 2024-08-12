using Domain;

namespace Service.DTOs.Student
{
    public class StudentForUpdateDto
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
    }
}
