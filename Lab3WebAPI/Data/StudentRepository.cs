using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class StudentRepository : IStudentRepository
  {
    private readonly DataContext _context;
    public StudentRepository(DataContext context)
    {
      _context = context;
    }

    public async Task AddAsync(Student student)
    {
      await _context.Students.AddAsync(student);
    }

    public void Delete(Student student)
    {
      _context.Students.Remove(student);
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
      return await _context.Students.Include(c => c.LastName).SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Student> GetStudentByPersonalNoAsync(string personalNo)
    {
      var student = await _context.Students.Include(c => c.LastName).SingleOrDefaultAsync(
          c => c.PersonalNumber.ToUpper() == personalNo.ToUpper());

      return student;
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
      return await _context.Students.Include(c => c.LastName).ToListAsync();
    }

    public async Task<bool> SaveAllChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Student student)
    {
      _context.Students.Update(student);
    }
  }
}