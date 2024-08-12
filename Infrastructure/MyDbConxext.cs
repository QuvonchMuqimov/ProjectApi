using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using System.Reflection;

namespace Infrastructure;

public class MyDbConxext : DbContext
{

    public MyDbConxext(DbContextOptions<MyDbConxext> options) : base(options) { }

    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
}
