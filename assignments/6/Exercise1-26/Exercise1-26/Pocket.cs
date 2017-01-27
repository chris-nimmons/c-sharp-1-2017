using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_26
{
    public class Pocket
    {
        public List<Contents> Contents { get; set; }
        public Volume Volume { get; set; }
        public Pocket(float length, float width, float height)
        {
            Contents = new List<Content>();
            Volume = new Volume();
        }
        public void Add(Content contents)
        {
            Contents.Add(contents);
        }
    }
}
