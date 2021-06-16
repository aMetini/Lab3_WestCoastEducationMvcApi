using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;

namespace App.Interfaces
{
  public interface ICourseService
  {
    Task<List<CourseModel>> GetCoursesAsync();
    Task<CourseModel> GetCourseAsync(int id);
    Task<CourseModel> GetCourseAsync(string courseNo);
    Task<bool> AddCourse(CourseModel model);
    Task<bool> UpdateCourse(int id, UpdateCourseViewModel model);
    Task<bool> DeleteCourse(string courseNo);
  }
}