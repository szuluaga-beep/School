using Microsoft.AspNetCore.Mvc.Rendering;

namespace School.Models.ViewModel
{
    public class StudentViewModel
    {
        public int SelectedCourse { get; set; }

        public List<SelectListItem> SelectListCourses { get; set; } = new List<SelectListItem>();

        public IEnumerable<Student> Students { get; set; } = new List<Student>();
    }
}