using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TinyUniversity.Models;

namespace TinyUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public IndexModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course
                .AsNoTracking()
                .Include(c => c.Department).ToListAsync();
        }
    }
}
