using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_24
{
    public class Instructor
    {
        public string Name
        {
            get
            {
                return GiveName + " " + SurName;
            }
        }
        public string GiveName { get; set; }
        public string SurName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
    }
}
