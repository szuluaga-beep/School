namespace School.Models
{
    public class CourseStudent
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}