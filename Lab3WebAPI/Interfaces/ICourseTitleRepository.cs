using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces
{
    public interface ICourseTitleRepository
    {
        Task<CourseTitle> GetTitleAsync(string title);
    }
}