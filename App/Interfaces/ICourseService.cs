using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;

namespace App.Interfaces
{
    // This interface service manipulates the data that it has access to using the Course Model and UpdateCourseViewModel
    public interface ICourseService
  {
    Task<List<CourseModel>> GetCoursesAsync();
    Task<CourseModel> GetCourseAsync(int id);
    Task<CourseModel> GetCourseByCourseNoAsync(int courseNo);
    Task<bool> AddCourse(CourseModel model);
    Task<bool> UpdateCourse(int id, UpdateCourseViewModel model);
    Task<bool> DeleteCourse(int courseNo);
  }
}