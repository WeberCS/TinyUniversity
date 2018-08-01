using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TinyUniversity.Models;
using TinyUniversity.Models.ViewModels;

namespace TinyUniversity.Pages.Instructors
{
    public class CreateModel : PageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public CreateModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InstructorIndexData InstructorIndexData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InstructorIndexData.Add(InstructorIndexData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}