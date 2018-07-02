using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUniversity.Models
{

    public enum GradeLetter
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public GradeLetter? Grade { get; set; } //?Nullable

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
