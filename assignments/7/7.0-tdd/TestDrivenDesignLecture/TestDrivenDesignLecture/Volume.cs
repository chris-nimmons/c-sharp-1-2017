using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Volume
    {
        private float _length;
        private float _width;
        private float _height;

        public float Length { get { return _length; } set { _length = Math.Abs(value); } }
        public float Width { get { return _width; } set { _width = Math.Abs(value); } }
        public float Height { get { return _height; } set { _height = Math.Abs(value); } }
        public float Value { get { return Length * Width * Height; } }

        public Volume(float length, float width, float height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}
