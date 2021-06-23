using System.Threading.Tasks;
using App.Interfaces;

namespace App.Interfaces
{
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        ICourseTitleRepository CourseTitleRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}