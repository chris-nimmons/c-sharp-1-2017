using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School() { Name = "Iron Yard" };
            school.Name = "Iron Yard";
            var spencer = new Student() { GiveName = "Spencer", SurName = "Oakes"};
            var chris = new Instructor() { GiveName = "Chris", SurName = "Nimmons"};

            school.Students.Add(new Student() { GiveName = "Colby", SurName = "Burke" });
            school.Students.Add(new Student() { GiveName = "Name", SurName = "Two" });
            school.Students.Add(new Student() { GiveName = "Number", SurName = "Three" });
            school.Instructors.Add(new Instructor() { GiveName = "Teacher", SurName = "One" });

            school.Students.Add(spencer);
            school.Instructors.Add(chris);

            var @class = new Class();
            @class.Instructor = chris;
            Console.Write("chris");
            Console.ReadLine();
            @class.Students.Add(spencer);
            Console.Write("spencer");
            Console.ReadLine();
        }
    }
}
