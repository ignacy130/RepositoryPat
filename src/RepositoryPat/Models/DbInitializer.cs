using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pat.Domain.Models;
using Pat.Domain.DAL;

namespace Pat.Domain.Models
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{Id=1, FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{Id=2, FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=3, FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Id=4, FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=5, FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Id=6, FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{Id=7, FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Id=8, FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{Id=1050,Title="Chemistry",Credits=3,},
            new Course{Id=4022,Title="Microeconomics",Credits=3,},
            new Course{Id=4041,Title="Macroeconomics",Credits=3,},
            new Course{Id=1045,Title="Calculus",Credits=4,},
            new Course{Id=3141,Title="Trigonometry",Credits=4,},
            new Course{Id=2021,Title="Composition",Credits=3,},
            new Course{Id=2042,Title="Literature",Credits=4,}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{Id=1, StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{Id=2, StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{Id=3, StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{Id=4, StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{Id=5, StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{Id=6, StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{Id=7, StudentID=3,CourseID=1050},
            new Enrollment{Id=8, StudentID=4,CourseID=1050,},
            new Enrollment{Id=9, StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{Id=10, StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{Id=11, StudentID=6,CourseID=1045},
            new Enrollment{Id=12, StudentID=7,CourseID=3141,Grade=Grade.A},
            };             
            foreach (Enrollment e in enrollments)
            {               
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}