using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUniversity.Models.ViewModels
{
    public class InstructorIndexData
    {

        public int ID { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable <Enrollment> Enrollments { get; set; }
    }
}
