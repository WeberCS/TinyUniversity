using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TinyUniversity.Models;

namespace TinyUniversity.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public CreateModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID");
            PopulateDepartmentDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //prevent overposting
            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",//prefix in form fields)
                s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
            {
                _context.Course.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDepartmentDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}