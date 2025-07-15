using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
        [Display(Name = "Course Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(10, ErrorMessage = "Course code cannot exceed 10 characters.")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; } = null!;

        [Range(1, 5)]
        public int Credits { get; set; }
    }
}