namespace App.Models
{
    // Course model defines properties and/or methods of a Course object
  public class CourseModel
  {
    public int Id { get; set; }
    public int CourseNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Length { get; set; }
    public string ImageName { get; set; }
    public string Category { get; set; }
    public string CourseLevel { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
  }
}