using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<TinyUniversity.Models.Course> Course { get; set; }  //Optional

    }
}
