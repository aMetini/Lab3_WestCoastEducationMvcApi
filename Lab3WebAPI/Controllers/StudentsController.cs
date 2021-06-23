using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Entities;
using Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("api/students")]
  public class StudentsController : ControllerBase
  {
    private readonly IStudentRepository _studentrepo;
    public StudentsController(IStudentRepository studentrepo)
    {
      _studentrepo = studentrepo;
    }

    [HttpGet()]
    public async Task<IActionResult> GetStudents()
    {
      var result = await _studentrepo.GetStudentsAsync();

      var students = new List<StudentViewModel>();

      if (result == null) return NotFound();

      foreach (var s in result)
      {
        students.Add(new StudentViewModel
        {
          Id = s.Id,
          FirstName = s.FirstName,
          LastName = s.LastName,
          Email = s.Email,
          MobileNumber = (string)s.MobileNumber,
          AddressInformation = s.AddressInformation,
          PersonalNumber = (string)s.PersonalNumber
        });
      }
      return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
      try
      {
        var student = await _studentrepo.GetStudentByIdAsync(id);

        if (student == null) return NotFound();

        var model = new StudentViewModel
        {
          Id = student.Id,
          FirstName = student.FirstName,
          LastName = student.LastName,
          Email = student.Email,
          MobileNumber = (string)student.MobileNumber,
          AddressInformation = student.AddressInformation,
          PersonalNumber = (string)student.PersonalNumber
        };

        return Ok(model);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpGet("find/{email}")]
    public async Task<IActionResult> GetStudentByEmail(string email)
    {
      try
      {
        var student = await _studentrepo.GetStudentByEmailAsync(email);

        if (student == null) return NotFound();

        var model = new StudentViewModel
        {
          Id = student.Id,
          FirstName = student.FirstName,
          LastName = student.LastName,
          Email = student.Email,
          MobileNumber = (string)student.MobileNumber,
          AddressInformation = student.AddressInformation,
          PersonalNumber = (string)student.PersonalNumber
        };

        return Ok(model);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }


    [HttpPost()]
    public async Task<IActionResult> AddStudent(AddStudentViewModel model)
    {
      try
      {

        var student = new Student
        {
          FirstName = model.FirstName,
          LastName = model.LastName,
          Email = model.Email,
          MobileNumber = (string)model.MobileNumber,
          AddressInformation = model.AddressInformation,
          PersonalNumber = (string)model.PersonalNumber
        };
        await _studentrepo.AddAsync(student);

        if (await _studentrepo.SaveAllChangesAsync()) return StatusCode(201);

        return StatusCode(500, "Unable to save changes. Please try again!");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentViewModel model)
    {

      var student = await _studentrepo.GetStudentByIdAsync(id);

      student.Email = student.Email;
      student.FirstName = student.FirstName;
      student.LastName = student.LastName;
      student.MobileNumber = (string)model.MobileNumber;
      student.AddressInformation = student.AddressInformation;
      student.PersonalNumber = (string)model.PersonalNumber;

      _studentrepo.Update(student);
      var result = await _studentrepo.SaveAllChangesAsync();

      return NoContent();
    }

    [HttpDelete("{personalNo}")]
    public async Task<IActionResult> DeleteStudent(int personalNo)
    {
      try
      {
        var student = await _studentrepo.GetStudentByIdAsync(personalNo);
        if (student == null) return NotFound();

        _studentrepo.Delete(student);
        var result = _studentrepo.SaveAllChangesAsync();

        return NoContent();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}

    
