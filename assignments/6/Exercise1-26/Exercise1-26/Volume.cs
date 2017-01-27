using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_26
{
    public class Volume
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Value
        {
            get { return Length * Width * Height;}

        }
        public Volume(float length, float width, float height)
        {
            Length = length;
            Width = width;
            Height = height;

        }
    }
}
