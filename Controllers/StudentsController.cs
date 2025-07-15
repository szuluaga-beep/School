using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using School.Models.ViewModel;

namespace School.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var model = await PopulateListCoursesAndStudents();

            return View(model);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            var model = new StudentViewModel();
            model.SelectListCourses = _context.Course
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CourseCode + " - " + c.Name
                }).ToList();
            model.Student = new Student();
            return View(model);
        }

        // Fix for MVC1004: Rename the parameter to avoid conflict with the property name in StudentViewModel.  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Student,SelectedCourse")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Course.FirstOrDefaultAsync(c => c.Id == studentViewModel.SelectedCourse);

                if (course == null)
                {
                    ModelState.AddModelError("SelectedCourse", "The selected course does not exist.");
                    return View(studentViewModel);
                }

                var studentExists = await _context.Student.FirstOrDefaultAsync(s => s.Email == studentViewModel.Student.Email);

                if (studentExists != null)
                {
                    ModelState.AddModelError("Student.Email", "A student with this email already exists.");
                    return View(studentViewModel);
                }

                
                var courseStudent = new CourseStudent
                {
                    Student = studentViewModel.Student,
                    Course = course
                };

                _context.Add(studentViewModel.Student);
                _context.Add(courseStudent);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Document")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        private async Task<StudentsViewModel> PopulateListCoursesAndStudents(string? selectedCourse = null)
        {
            var courses = await _context.Course
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();

            var students = await _context.Student
                .Include(s => s.CourseStudents)
                .ThenInclude(cs => cs.Course)
                .AsNoTracking()
                .ToListAsync();

            var model = new StudentsViewModel();

            model.Students = students;

            foreach (var course in courses)
            {
                model.SelectListCourses.Add(new SelectListItem
                {
                    Value = course.Id.ToString(),
                    Text = course.CourseCode + " - " + course.Name,
                    Selected = selectedCourse != null && selectedCourse == course.Id.ToString()
                });
            }

            return model;
        }
    }
}