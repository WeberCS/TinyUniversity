using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TinyUniversity.Models;
using TinyUniversity.Models.ViewModels;

namespace TinyUniversity.Pages.Instructors
{
    public class EditModel : InstructorCoursesPageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public EditModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InstructorIndexData InstructorIndexData { get; set; }
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound("id");
            }

            Instructor = await _context.Instructor
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound("Instructor");
            }

            //InstructorIndexData = await _context.InstructorIndexData.FirstOrDefaultAsync(m => m.ID == id);

            //if (InstructorIndexData == null)
            //{
            //    return NotFound("IndexData");
            //}

            PopulateAssignedCourseData(_context, Instructor);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = await _context.Instructor
                        .Include(i => i.OfficeAssignment)
                        .Include(i => i.CourseAssignments)
                            .ThenInclude(i => i.Course)
                        .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Instructor>(
                instructorToUpdate,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                if (String.IsNullOrWhiteSpace(
                    instructorToUpdate.OfficeAssignment?.Location))
                {
                    instructorToUpdate.OfficeAssignment = null;
                }
                UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
            PopulateAssignedCourseData(_context, instructorToUpdate);
            return Page();
        }


        private bool InstructorIndexDataExists(int id)
        {
            return _context.InstructorIndexData.Any(e => e.ID == id);
        }
    }
}
