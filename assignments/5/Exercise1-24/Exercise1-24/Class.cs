using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    public class Class
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public Instructor Instructor { get; set; }


        public Class()
        {
            var instructor = new Instructor();
            Students = new List<Student>();
        }

    }
}

