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
    public class EditModel : PageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public EditModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InstructorIndexData InstructorIndexData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InstructorIndexData = await _context.InstructorIndexData.FirstOrDefaultAsync(m => m.ID == id);

            if (InstructorIndexData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InstructorIndexData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorIndexDataExists(InstructorIndexData.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InstructorIndexDataExists(int id)
        {
            return _context.InstructorIndexData.Any(e => e.ID == id);
        }
    }
}
