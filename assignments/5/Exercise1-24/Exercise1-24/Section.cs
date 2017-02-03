using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    public class Section
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public Instructor Instructor { get; set; }

        public List<Class> Classes { get; set; }

        public Section()
        {
            Classes = new List<Class>();
            var instructor = new Instructor();
            Students = new List<Student>();
        }
    }
}
