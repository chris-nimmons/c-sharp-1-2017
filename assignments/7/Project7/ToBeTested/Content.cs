using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Content
    {
        public Volume Volume { get; set; }
        public float Weight { get; set; }
        public string Name { get; set; }

        public Content(float length, float width, float height)
        {
            Volume = new Volume(length, width, height);
        }
    }

}