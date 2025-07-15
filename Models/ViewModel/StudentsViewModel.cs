using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace School.Models.ViewModel
{
    public class CourseSelection
    {
        [Required(ErrorMessage ="The course is required")]
        public int SelectedCourse { get; set; }

        [Display(Name ="Course")]
        public List<SelectListItem> SelectListCourses { get; set; } = new List<SelectListItem>();
    }

    public class StudentsViewModel : CourseSelection
    {
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
    }

    public class StudentViewModel : CourseSelection
    {
        public Student Student { get; set; } = new Student();
    }
}