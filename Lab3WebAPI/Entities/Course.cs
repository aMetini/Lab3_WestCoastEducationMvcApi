using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string ImageName { get; set; }
        public string Category { get; set; }
        public string CourseLevel { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        //Foreign key constraint
        [ForeignKey("StudentId")]
        public virtual Student PersonalNumber { get; set; }
    }
}