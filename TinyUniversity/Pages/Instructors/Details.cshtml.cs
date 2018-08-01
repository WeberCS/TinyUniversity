using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TinyUniversity.Models;
using TinyUniversity.Models.ViewModels;

namespace TinyUniversity.Pages.Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public DetailsModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
