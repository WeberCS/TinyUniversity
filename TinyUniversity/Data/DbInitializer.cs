using TinyUniversity.Models;
using System;
using System.Linq;
namespace TinyUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Student.Any())
            {
                return; // DB has been seeded
            }
            var students = new Student[]
            {
new Student{FirstMidName="Chase",LastName="Greenwood",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Spencer",LastName="Harston",EnrollmentDate=DateTime.Parse("2016-09-01")},
new Student{FirstMidName="Mark",LastName="Haslam",EnrollmentDate=DateTime.Parse("2016-09-01")},
new Student{FirstMidName="Dongmin",LastName="Kim",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Dewey",LastName="Lakey",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Nicholas",LastName="Lambert",EnrollmentDate=DateTime.Parse("2016-09-01")},
new Student{FirstMidName="Amy",LastName="Lea",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Andrew",LastName="Merrell",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Belete",LastName="Nigusie",EnrollmentDate=DateTime.Parse("2015-09-01")},
new Student{FirstMidName="Johnathan",LastName="Warnes",EnrollmentDate=DateTime.Parse("2015-09-01")}
};
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges(); var courses = new Course[]
 {
new Course{CourseID=1030,Title="Intro to Computer Science",Credits=4},
new Course{CourseID=3750,Title="Software Engineering II",Credits=4},
new Course{CourseID=4790,Title="MVC Web Programming",Credits=4},
new Course{CourseID=1210,Title="Calculus I",Credits=3},
new Course{CourseID=1060,Title="Trigonometry",Credits=3},
new Course{CourseID=2010,Title="Composition",Credits=3},
new Course{CourseID=2020,Title="Literature",Credits=3}
 };
            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
new Enrollment{StudentID=1,CourseID=1030,Grade=GradeLetter.A},
new Enrollment{StudentID=1,CourseID=3750,Grade=GradeLetter.C},
new Enrollment{StudentID=1,CourseID=4790,Grade=GradeLetter.B},
new Enrollment{StudentID=2,CourseID=1030,Grade=GradeLetter.B},
new Enrollment{StudentID=2,CourseID=3750,Grade=GradeLetter.F},
new Enrollment{StudentID=2,CourseID=2020,Grade=GradeLetter.F},
new Enrollment{StudentID=3,CourseID=1030},
new Enrollment{StudentID=4,CourseID=1030},
new Enrollment{StudentID=4,CourseID=4790,Grade=GradeLetter.F},
new Enrollment{StudentID=5,CourseID=4790,Grade=GradeLetter.C},
new Enrollment{StudentID=6,CourseID=1060},
new Enrollment{StudentID=7,CourseID=1210,Grade=GradeLetter.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollment.Add(e);
            }
            context.SaveChanges();
        }
    }
}