using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    // This view model class consists of all properties required by the Edit view in the Student Page.
    public class EditStudentViewModel
  {
    public int Id { get; set; }
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Display(Name = "Mobile Number")]
    public string MobileNumber { get; set; }
    [Display(Name = "Address Information")]
    public string AddressInformation { get; set; }
    [Display(Name = "Personal Number")]
    public string PersonalNumber { get; set; }
    [Display(Name = "Course ID")]
    public int CourseId { get; set; }

  }
}