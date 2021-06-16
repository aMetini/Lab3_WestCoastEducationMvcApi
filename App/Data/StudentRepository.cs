using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities;
using App.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
  public class StudentRepository : IStudentRepository
  {
    private readonly DataContext _context;
    public StudentRepository(DataContext context)
    {
      _context = context;
    }
    public void Add(Student student)
    {
      _context.Students.Add(student);
    }
     public void Delete(Student student)
    {
      _context.Students.Remove(student);
    }
    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
      return await _context.Students.ToListAsync();
    }
   
    public async Task<Student> GetStudentByIdAsync(int id)
    {
      return await _context.Students.FindAsync(id);
    }
    public async Task<Student> GetStudentByEmailAsync(string studentEmail)
    {
      return await _context.Students.SingleOrDefaultAsync(c => c.Email.ToLower() == studentEmail.ToLower());
    }
    public void Update(Student student)
    {
      _context.Students.Update(student);
    }
  }
}