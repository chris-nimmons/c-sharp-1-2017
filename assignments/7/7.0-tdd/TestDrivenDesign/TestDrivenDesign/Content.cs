using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
    public class Content
    {
        public Volume Volume { get; set; }
        public decimal Weight { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public Content(decimal length, decimal height, decimal width, string name, decimal weight)
        {
            Volume = new Volume(length, height, width);
            Weight = weight;
            Name = name;
        }
    }
}
