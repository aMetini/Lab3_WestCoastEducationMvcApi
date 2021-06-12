using System.Threading.Tasks;
using Api.Entities;
using System.Collections.Generic;
using Api.ViewModels;

namespace Api.Interfaces
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByPersonalNoAsync(string personalNo);
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> GetLastNameAsync(string LastName);
        void Update(Student student);
        void Delete(Student student);
        Task<bool> SaveAllChangesAsync();
    }
}