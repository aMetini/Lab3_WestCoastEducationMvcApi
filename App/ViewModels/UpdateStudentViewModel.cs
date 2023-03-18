namespace App.ViewModels
{
    // This view model class consists of all properties required to update Index View in Student Page.
    public class UpdateStudentViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string AddressInformation { get; set; }
    public string PersonalNumber { get; set; }
    public int CourseId { get; set; }
  }
}