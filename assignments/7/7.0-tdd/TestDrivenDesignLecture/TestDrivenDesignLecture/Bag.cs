using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Bag
    {
        private float _weight;

        public string Color { get; set; }
        public Volume Volume { get; set; }
        public float Weight { get { return _weight; } set { _weight = Math.Abs(value); } }
        public List<Pocket> Pockets { get; set; }
        private List<Content> Contents { get; set; }        
        public Condition Condition { get; set; }

        public Bag(float length, float width, float height)
        {
            Contents = new List<Content>();
            Pockets = new List<Pocket>();
            Volume = new Volume(length, width, height);
        }

        public bool Add(Content content)
        {
            if (content.Volume.Length <= Volume.Length &&
                content.Volume.Width <= Volume.Width &&
                content.Volume.Height <= Volume.Height)
            {
                Contents.Add(content);
                return true;
            }
            else
            {
                return false;
            }         
        }

        public bool Remove(Content content)
        {
            return Contents.Remove(content);
        }

        public bool Check(Content content)
        {
            return Contents.Contains(content);
        }

        public List<Content> Dump()
        {
            var swapped = new List<Content>(Contents);
            Contents.Clear();
            return swapped;
        }
    }
}
