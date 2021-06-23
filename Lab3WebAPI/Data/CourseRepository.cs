using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class CourseRepository : ICourseRepository
  {
    private readonly DataContext _context;
    public CourseRepository(DataContext context)
    {
      _context = context;
    }

    public async Task AddAsync(Course course)
    {
      await _context.Courses.AddAsync(course);
    }

    public void Delete(Course course)
    {
      _context.Courses.Remove(course);
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
      return await _context.Courses./*Include(c => c.Title).*/FindAsync(id);
    }

    public async Task<Course> GetCourseByCourseNoAsync(string courseNo)
    {
      var course = await _context.Courses/*.Include(c => c.Title)*/.SingleOrDefaultAsync(
          c => c.CourseNumber.ToUpper() == courseNo.ToUpper());

      return course;
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
      return await _context.Courses /*.Include(c => c.Title)*/.ToListAsync();
    }

    public async Task<bool> SaveAllChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Course course)
    {
      _context.Courses.Update(course);
    }
  }
}