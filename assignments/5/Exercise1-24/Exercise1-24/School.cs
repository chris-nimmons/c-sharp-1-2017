using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    public class School
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<Instructor> Instructors { get; set; }

        public List<Class> Classes { get; set;}

        public List<Department> Departments { get; set; }

        public School()
        {
            Departments = new List<Department>();
            Classes = new List<Class>();
            Instructors = new List<Instructor>();
            Students = new List<Student>();
        }
    }
}
