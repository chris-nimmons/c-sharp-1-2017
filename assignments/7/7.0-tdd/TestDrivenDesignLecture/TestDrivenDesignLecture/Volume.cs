using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Volume
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Value { get { return Length * Width * Height; } }

        public Volume(float length, float width, float height)
        {
            Length = Math.Abs(length);
            Width = Math.Abs(width);
            Height = Math.Abs(height);
        }
    }
}
