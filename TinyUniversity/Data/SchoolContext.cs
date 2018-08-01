using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinyUniversity.Models.ViewModels;

namespace TinyUniversity.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<TinyUniversity.Models.Student> Student { get; set; }
        public DbSet<TinyUniversity.Models.Enrollment> Enrollment { get; set; }
        public DbSet<TinyUniversity.Models.Course> Course { get; set; }

        public DbSet<TinyUniversity.Models.Instructor> Instructor { get; set; }
        public DbSet<TinyUniversity.Models.CourseAssignment> CourseAssignment { get; set; }
        public DbSet<TinyUniversity.Models.OfficeAssignment> OfficeAssignment { get; set; }
        public DbSet<TinyUniversity.Models.Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Department>().ToTable("Department");
            //do the other 5 tables for consistency

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }

        public DbSet<TinyUniversity.Models.ViewModels.InstructorIndexData> InstructorIndexData { get; set; }

    }
}
