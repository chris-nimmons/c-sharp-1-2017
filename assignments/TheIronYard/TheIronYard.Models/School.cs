using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheIronYard.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Department> Departments { get; set; }

        public School()
        {
            Instructors = new List<Instructor>();
            Courses = new List<Course>();
            Students = new List<Student>();
            Departments = new List<Department>();
        }
    }
}
