using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseTitle> CourseTitles { get; set; }
    //public DbSet<StudentCourse> StudentCourses { get; set; } 

    public DataContext(DbContextOptions options) : base(options)
    {
    }
  }
}