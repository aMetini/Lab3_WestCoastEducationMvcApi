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
  [Route("api/courses")]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _repo;
    //private readonly ICourseTitleRepository _titlerepo;
    public CoursesController(ICourseRepository repo /*ICourseTitleRepository titlerepo*/)
    {
      _repo = repo;
      //_titlerepo = titlerepo;
    }

    [HttpGet()]
    public async Task<IActionResult> GetCourses()
    {
      var result = await _repo.GetCoursesAsync();

      var courses = new List<CourseViewModel>();

      if (result == null) return NotFound();

      foreach (var c in result)
      {
        courses.Add(new CourseViewModel
        {
          Id = c.Id,
          CourseNumber = c.CourseNumber,
          Title = c.Title,
          Description = c.Description,
          Length = c.Length,
          ImageName = c.ImageName,
          Category = c.Category,
          CourseLevel = c.CourseLevel,
          Price = c.Price,
          Status = c.Status
        });
      }
      return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
      try
      {
        var course = await _repo.GetCourseByIdAsync(id);

        if (course == null) return NotFound();

        var model = new CourseViewModel
        {
          Id = course.Id,
          CourseNumber = course.CourseNumber,
          Title = course.Title,
          Description = course.Description,
          Length = course.Length,
          ImageName = course.ImageName,
          Category = course.Category,
          CourseLevel = course.CourseLevel,
          Price = course.Price,
          Status = course.Status
        };

        return Ok(model);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpGet("find/{courseno}")]
    public async Task<IActionResult> GetCourseByCourseNo(string courseno)
    {
      try
      {
        var course = await _repo.GetCourseByCourseNoAsync(courseno);

        if (course == null) return NotFound();

        var model = new CourseViewModel
        {
          Id = course.Id,
          CourseNumber = course.CourseNumber,
          Title = course.Title,
          Description = course.Description,
          Length = course.Length,
          ImageName = course.ImageName,
          Category = course.Category,
          CourseLevel = course.CourseLevel,
          Price = course.Price,
          Status = course.Status
        };

        return Ok(model);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }


    [HttpPost()]
    public async Task<IActionResult> AddCourse(AddCourseViewModel model)
    {
      try
      {
/*
        var title = await _titlerepo.GetTitleAsync(model.Title);

        if (title == null) return NotFound("Could not find course with course title: " + model.Title);*/

        var course = new Course
        {
          CourseNumber = model.CourseNumber,
          Title = model.Title,
          Description = model.Description,
          Length = model.Length,
          ImageName = model.ImageName,
          Category = model.Category,
          CourseLevel = model.CourseLevel,
          Price = (decimal)model.Price,
          Status = model.Status
        };
        await _repo.AddAsync(course);

        if (await _repo.SaveAllChangesAsync()) return StatusCode(201);

        return StatusCode(500, "Unable to save changes. Please try again!");
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, UpdateCourseViewModel model)
    {

      var course = await _repo.GetCourseByIdAsync(id);

      course.CourseLevel = course.CourseLevel;
      course.Status = course.Status;
      course.Title = course.Title;
      course.Length = model.Length;
      course.Description = course.Description;
      course.Price = (decimal)model.Price;

      _repo.Update(course);
      var result = await _repo.SaveAllChangesAsync();

      return NoContent();
    }

    [HttpDelete("{courseNo}")]
    public async Task<IActionResult> DeleteCourse(string courseNo)
    {
      try
      {
        var course = await _repo.GetCourseByCourseNoAsync(courseNo);
        if (course == null) return NotFound();

        _repo.Delete(course);
        var result = _repo.SaveAllChangesAsync();

        return NoContent();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }
  }
}

    
