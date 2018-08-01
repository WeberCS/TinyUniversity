using TinyUniversity.Models;
using TinyUniversity.Models.ViewModels;  // Add VM
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TinyUniversity.Data;
using System.Threading.Tasks;

namespace TinyUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly TinyUniversity.Models.SchoolContext _context;

        public IndexModel(TinyUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public InstructorIndexData Instructor { get; set; }
        public int InstructorID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Instructor = new InstructorIndexData();
            Instructor.Instructors = await _context.Instructor
                  .Include(i => i.OfficeAssignment)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                  .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();

            if (id != null)
            {
                InstructorID = id.Value;
            }
        }
    }
}