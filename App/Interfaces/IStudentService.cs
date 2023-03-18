using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels;

namespace App.Interfaces
{
    // This interface service manipulates the data that it has access to using the Student Model and UpdateStudentViewModel
  public interface IStudentService
  {
    Task<List<StudentModel>> GetStudentsAsync();
    Task<StudentModel> GetStudentAsync(int id);
    Task<StudentModel> GetStudentAsync(string studentEmail);
    Task<bool> AddStudent(StudentModel model);
    Task<bool> UpdateStudent(int id, UpdateStudentViewModel model);
    Task<bool> DeleteStudent(int id);
  }
}