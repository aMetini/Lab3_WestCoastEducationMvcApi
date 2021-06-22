using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class DataContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseTitle> CourseTitles { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DataContext(DbContextOptions options) : base(options) { }
/*
    protected override void onConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite();
    }
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<StudentCourse>()
        .HasKey(cs => new { cs.StudentId, cs.CourseId});
      base.OnModelCreating(modelBuilder);
    }
  }
}