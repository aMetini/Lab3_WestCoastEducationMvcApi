using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
    // This interface repository stores/accesses data for the CourseTitle entity
    public interface ICourseTitleRepository
  {
    void Add(CourseTitle courseTitle);
    Task<IEnumerable<CourseTitle>> GetCourseTitlesAsync();
  }
}