using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    //public DbSet<CourseTitle> CourseTitles { get; set; }
    //public DbSet<StudentCourse> StudentCourses { get; set; }
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      /*modelBuilder.Entity<StudentCourse>()
        .HasKey(sc => new { sc.StudentId, sc.CourseId});
      modelBuilder.Entity<StudentCourse>()
        .HasOne(sc => sc.Student)
        .WithMany(s => s.StudentCourses)
        .HasForeignKey(sc => sc.StudentId);
      modelBuilder.Entity<StudentCourse>()
        .HasOne(sc => sc.Course)
        .WithMany(c => c.StudentCourses)
        .HasForeignKey(sc => sc.CourseId);*/
      base.OnModelCreating(modelBuilder);
    }
  }
}