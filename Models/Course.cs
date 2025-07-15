using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [Required]
        [StringLength(10, ErrorMessage = "Course code cannot exceed 10 characters.")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; } = null!;

        [Range(1, 5, ErrorMessage = "Credits must be between {0} and {1}.")]
        public int Credits { get; set; }
    }
}