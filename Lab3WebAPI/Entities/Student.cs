using System.ComponentModel.DataAnnotations.Schema;


namespace Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public string AddressInformation { get; set; }
        public int PersonalNumber { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}