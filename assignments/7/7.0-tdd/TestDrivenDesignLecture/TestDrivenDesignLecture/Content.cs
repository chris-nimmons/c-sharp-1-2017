using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Content
    {
        private float _weight;

        public Volume Volume { get; set; }
        public float Weight { get { return _weight; } set { _weight = Math.Abs(value); } }
        public string Name { get; set; }

        public Content(float length, float width, float height)
        {
            Volume = new Volume(length, width, height);
        }
    }
}
