using Exercise1_31_17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Cars car = new Cars();
            var context = new SchoolsContext();
            context.Configuration.LazyLoadingEnabled = true;

            var meow = context.Schools
                .Include(q => q.Courses)
                .Include(q => q.Students)
                .Include(q => q.Instructors)
                .First(q => q.Name == "The Iron Yard");

            
            
            Car car = null;
            if (!context.Schools.Any(q => q.Name == "The Iron Yard"))
            {
                var car = new Car() { Name = "The Iron Yard" };
                context.Schools.Add(school);
            }
            else
            {
                school = context.Schools.FirstOrDefault(q => q.Name == "The Iron Yard");
            }

            Instructor instructor = null;
            if (!context.Instructors.Any(q => q.Name == "Chris"))
            {
                instructor = new Instructor() { Name = "Chris" };
                school.Instructors.Add(instructor);
                context.Instructors.Add(instructor);
            }
            else
            {
                instructor = context.Instructors.FirstOrDefault(q => q.Name == "Chris");
                if (!school.Instructors.Any(q => q.Name == instructor.Name))
                {
                    school.Instructors.Add(instructor);
                }
            }

            Course course = null;
            if (!context.Courses.Any(q => q.Name == ".Net C#"))
            {
                course = new Course() { Name = ".Net C#" };
                course.Instructor = instructor;
                context.Courses.Add(course);
            }
            else
            {
                course = context.Courses.FirstOrDefault(q => q.Name == ".Net C#");
                if (course.Instructor == null || course.Instructor.Name != "Chris")
                {
                    course.Instructor = instructor;
                }
            }

            if (!context.Students.Any())
            {
                var students = new List<Student>();

                students.Add(new Student() { Name = "Sargent Baloney" });
                students.Add(new Student() { Name = "Hyper Student" });

                foreach (var student in students)
                {
                    course.Students.Add(student);
                    school.Students.Add(student);
                }
            }

            context.SaveChanges();
        }
    }
}




