using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    public class Department
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<Instructor> Instructors { get; set; }

        public List<Class> Classes { get; set; }

        public List<Section> Sections { get; set; }

        public Department()
        {
            Sections = new List<Section>();
            Classes = new List<Class>();
            Instructors = new List<Instructor>();
            Students = new List<Student>();
        }
    }
}
