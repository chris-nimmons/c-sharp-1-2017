using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_26
{
    public class Content
    {
        public Volume Volume { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }

        public Content()
        {
            Volume = new Volume();
        }
    }
}
