using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
  public interface ICourseTitleRepository
  {
    void Add(CourseTitle courseTitle);
    Task<IEnumerable<CourseTitle>> GetCourseTitlesAsync();
  }
}