using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;
using App.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
  public class CourseTitleRepository : ICourseTitleRepository
  {
    private readonly DataContext _context;
    public CourseTitleRepository(DataContext context)
    {
      _context = context;
    }
    public void Add(CourseTitle courseTitle)
    {
      _context.Add(courseTitle);
    }
    public async Task<IEnumerable<CourseTitle>> GetCourseTitlesAsync()
    {
      return await _context.CourseTitles.ToListAsync();
    }
  }
}