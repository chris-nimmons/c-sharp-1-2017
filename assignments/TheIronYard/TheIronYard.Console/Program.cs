using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheIronYard.Models;

namespace TheIronYard.Context
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolsContext();
            context.Database.Delete();
            context.Database.Create();

            context.Schools.Add(new School() { Name = "The Iron Yard" });
            context.Courses.Add(new Course() { Name = "Backend C#/.NET" });
            context.Instructors.Add(new Instructor() { Name = "Chris Nimmons" });
            context.Students.AddRange(new List<Student>()
            {
                new Student() { Name = "Alex Marcondes" },
                new Student() { Name = "Colby Burke" },
                new Student() { Name = "Jeff Heffner" },
                new Student() { Name = "Jeff Weinreich" },
                new Student() { Name = "Mackenzie Lewerke" },
                new Student() { Name = "Parker Tankersley" },
                new Student() { Name = "Spencer Oakes" }
            });
            context.SaveChanges();

            // Add all the students to the school
            context.Schools.FirstOrDefault(s => s.Name.Contains("Iron"))
                .Students.AddRange(context.Students);

            // Add all the students to the course
            context.Courses.FirstOrDefault(c => c.Name.Contains("Back"))
                .Students.AddRange(context.Students);

            // Add the instructor to the course
            context.Courses.FirstOrDefault(c => c.Name.Contains("Back")).Instructor 
                = context.Instructors.FirstOrDefault(i => i.Name.Contains("Chris"));

            // Add the instructor to the school
            context.Schools.FirstOrDefault(s => s.Name.Contains("Iron"))
                .Instructors.Add(context.Instructors.FirstOrDefault(i => i.Name.Contains("Chris")));

            context.SaveChanges();
        }
    }
}
