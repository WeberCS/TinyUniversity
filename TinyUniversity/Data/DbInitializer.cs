using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TinyUniversity.Models;

namespace TinyUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Chase",   LastName = "Greenwood",
                    EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Student { FirstMidName = "Spencer", LastName = "Harston",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { FirstMidName = "Mark",   LastName = "Haslam",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Dongmin",    LastName = "Kim",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Dewey",      LastName = "Lakey",
                    EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Student { FirstMidName = "Nicholas",    LastName = "Lambert",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Amy",    LastName = "Lea",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Andrew",     LastName = "Merrell",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Belete",     LastName = "Nigusie",
                    EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Johnathan",     LastName = "Warnes",
                    EnrollmentDate = DateTime.Parse("2016-09-01") }
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Richard",     LastName = "Fry",
                    HireDate = DateTime.Parse("2001-03-11") },
                new Instructor { FirstMidName = "Brian",    LastName = "Rague",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Spencer",   LastName = "Hilton",
                    HireDate = DateTime.Parse("2008-07-01") },
                new Instructor { FirstMidName = "Drew", LastName = "Weidman",
                    HireDate = DateTime.Parse("2011-01-15") },
                new Instructor { FirstMidName = "Linda",   LastName = "DuHadaway",
                    HireDate = DateTime.Parse("2014-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructor.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Computer Science",     Budget = 350000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Fry").ID },
                new Department { Name = "Web UX", Budget = 100000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Hilton").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Rague").ID },
                new Department { Name = "Networking",   Budget = 100000,
                    StartDate = DateTime.Parse("2017-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "DuHadaway").ID }
            };

            foreach (Department d in departments)
            {
                context.Department.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1030, Title = "Intro to Engineering",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 4200, Title = "Wireless Security", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Networking").DepartmentID
                },
                new Course {CourseID = 4800, Title = "Independent Project", Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {CourseID = 2500, Title = "The User Experience",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Web UX").DepartmentID
                },
                new Course {CourseID = 3100, Title = "Operating Systems",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Computer Science").DepartmentID
                },
                new Course {CourseID = 2705, Title = "Local Area Networks",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Networking").DepartmentID
                },
                new Course {CourseID = 1430, Title = "JavaScript",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Web UX").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Fry").ID,
                    Location = "EH 383" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Hilton").ID,
                    Location = "TE 273" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "DuHadaway").ID,
                    Location = "TE 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignment.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Local Area Networks" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Rague").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "DuHadaway").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fry").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Hilton").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Wireless Security" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Weidman").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Rague").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignment.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Greenwood").ID,
                    CourseID = courses.Single(c => c.Title == "Intro to Engineering" ).CourseID,
                    Grade = GradeLetter.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Warnes").ID,
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    Grade = GradeLetter.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Lakey").ID,
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Lea").ID,
                    CourseID = courses.Single(c => c.Title == "The User Experience" ).CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Kim").ID,
                    CourseID = courses.Single(c => c.Title == "Wireless Security" ).CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Harston").ID,
                    CourseID = courses.Single(c => c.Title == "Operating Systems" ).CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Merrell").ID,
                    CourseID = courses.Single(c => c.Title == "Independent Project" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Lambert").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = GradeLetter.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Haslam").ID,
                    CourseID = courses.Single(c => c.Title == "Local Area Networks").CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Lea").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = GradeLetter.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Greenwood").ID,
                    CourseID = courses.Single(c => c.Title == "Independent Project").CourseID,
                    Grade = GradeLetter.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollment.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollment.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}