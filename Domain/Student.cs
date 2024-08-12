namespace Domain;

public class Student
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int? Age { get; set; }
    public Gender Gender { get; set; }
    public List<Teacher>? Teachers { get; set; }
}
