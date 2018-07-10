using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Models
using System.ComponentModel.DataAnnotations.Schema; //DataBase


namespace TinyUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }

   
}
