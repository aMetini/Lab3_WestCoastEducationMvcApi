using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class CourseTitleRepository : ICourseTitleRepository
  {
    private readonly DataContext _context;
    public CourseTitleRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<CourseTitle> GetTitleAsync(string title)
    {
      return await _context.CourseTitles.SingleOrDefaultAsync(c => c.Title.ToLower() == title.ToLower());
    }
  }
}