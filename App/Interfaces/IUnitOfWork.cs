using System.Threading.Tasks;
using App.Interfaces;

namespace App.Interfaces
{
    /*Abstraction layer between business logic and data access layer. This ensures that multiple respositories share a single
    database context. This ensures that when a unit of work is complete one can call the HasChanges and Complete methods,
    and the related changes will be coordinated */
    public interface IUnitOfWork
    {
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        ICourseTitleRepository CourseTitleRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}