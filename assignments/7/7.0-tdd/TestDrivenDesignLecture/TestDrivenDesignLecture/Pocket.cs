using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Pocket
    {
        private List<Content> Contents { get; set; }
        public Volume Volume { get; set; }

        public Pocket(float length, float width, float height)
        {
            Contents = new List<Content>();
            Volume = new Volume(length, width, height);
        }

        public bool Add(Content content)
        {
            if (content.Volume.Width <= Volume.Width &&
                content.Volume.Length <= Volume.Length &&
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
            var swapper = new List<Content>(Contents);
            Contents.Clear();
            return swapper;
        }


    }
}
