using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Student name cannot exceed 100 characters.")]
        [Display(Name = "Student Name")]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Identity Document")]
        public string Document { get; set; } = null!;

        public List<CourseStudent> CourseStudents { get; set; } = [];
        public List<Course> Courses { get; set; } = [];
    }
}