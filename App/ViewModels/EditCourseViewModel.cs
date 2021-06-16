using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
  public class EditCourseViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Course Number")]
    public string CourseNumber { get; set; }
    [Display(Name = "Course Title")]
    public string Title { get; set; }
    [Display(Name = "Course Description")]
    public string Description { get; set; }
    [Display(Name = "Course Length")]
    public int Length { get; set; }
    [Display(Name = "Image Name")]
    public string ImageName { get; set; }
    [Display(Name = "Category")]
    public string Category { get; set; }
    [Display(Name = "Course Level")]
    public string CourseLevel { get; set; }
    [Display(Name = "Price")]
    public int Price { get; set; }
    [Display(Name = "Course Status")]
    public string Status { get; set; }
  }
}