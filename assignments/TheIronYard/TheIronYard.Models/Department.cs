using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheIronYard.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public virtual School School { get; set; }

        public Department()
        {
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }
    }
}
