using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
    public class Volume
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Value { get; set; }

        public Volume(decimal length, decimal width, decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
            Value = (length * width * height);
        }
    }
}
