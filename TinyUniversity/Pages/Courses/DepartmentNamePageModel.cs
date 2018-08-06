using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TinyUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace TinyUniversity.Pages.Courses
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentDropDownList (SchoolContext _context, object selectedDepartment = null)
        {
            var departmentQuery = from d in _context.Department
                                  orderby d.Name
                                  select d;

            DepartmentNameSL = new SelectList(departmentQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
    }
}
