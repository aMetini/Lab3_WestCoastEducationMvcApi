namespace App.Entities
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        //public List<Course> Courses { get; set; }
    }
}

/*
public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public List<StudentCourse> StudentCourses { get; set; }
}*/