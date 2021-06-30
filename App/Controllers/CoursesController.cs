using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using App.Entities;
using App.Interfaces;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
  public class CoursesController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseService _service;
    public CoursesController(IUnitOfWork unitOfWork, ICourseService service)
    {
      _service = service;
      _unitOfWork = unitOfWork;
    }

    //Action metod...
    [HttpGet()]
    public async Task<IActionResult> Index(string searchString)
    {
      var result = await _service.GetCoursesAsync();

      if(!string.IsNullOrEmpty(searchString))
      {
        var resultFiltered = result.Where(c => c.CourseNumber.Contains(searchString));
        return View("Index", resultFiltered);
      } 
      return View("Index", result);
    }

    //Steg 1.
    [HttpGet]
    public async Task<IActionResult> Create()
    {
      var list = await _unitOfWork.CourseTitleRepository.GetCourseTitlesAsync();
      return View("Create");
    }

    //Steg 3.
    [HttpPost]
    public async Task<IActionResult> Create(RegisterCourseViewModel data)
    {
      if (!ModelState.IsValid) return View("Create", data);
      var course = new CourseModel
      {
        CourseNumber = data.CourseNumber,
        Title = data.Title,
        Description = data.Description,
        Length = data.Length,
        ImageName = data.ImageName,
        Category = data.Category,
        CourseLevel = data.CourseLevel,
        Price = data.Price,
        Status = data.Status,
      };

      try
      {
        if (await _service.AddCourse(course)) return RedirectToAction("Index");
      }
      catch (System.Exception)
      {
        return View("Error");
      }

      return View("Error");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

      var course = await _service.GetCourseAsync(id);

      var model = new EditCourseViewModel
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

      return View("Edit", model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCourseViewModel data)
    {
      try
      {
        var course = await _service.GetCourseAsync(data.Id);

        var courseModel = new UpdateCourseViewModel
        {
          CourseNumber = data.CourseNumber,
          Title = data.Title,
          Description = data.Description,
          Length = data.Length,
          ImageName = data.ImageName,
          Category = data.Category,
          CourseLevel = data.CourseLevel,
          Price = data.Price,
          Status = data.Status,
        };

        if (await _service.UpdateCourse(data.Id, courseModel)) return RedirectToAction("Index");

        return View("Error");
      }
      catch (System.Exception)
      {
        return View("Error");
      }
    }

    public async Task<IActionResult> Details(string courseNo)
    {
      var result = await _service.GetCourseAsync(courseNo);
      if (result != null) return Content($"Course with course number {courseNo}");

      return Content($"Could not find course with course number {courseNo}");
    }

    public async Task<IActionResult> Delete(string courseNo)
    {
      if (await _service.DeleteCourse(courseNo)) return RedirectToAction("Index");
      return View("Error");
    }
  }
}