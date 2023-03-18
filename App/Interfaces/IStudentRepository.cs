using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;

namespace App.Interfaces
{
    // This interface repository stores/accesses data for the Student entity
  public interface IStudentRepository
  {
    void Add(Student student);
    Task<IEnumerable<Student>> GetStudentsAsync();
    Task<Student> GetStudentByEmailAsync(string studentEmail);
    Task<Student> GetStudentByIdAsync(int id);
    void Update(Student student);
    void Delete(Student student);
  }
}