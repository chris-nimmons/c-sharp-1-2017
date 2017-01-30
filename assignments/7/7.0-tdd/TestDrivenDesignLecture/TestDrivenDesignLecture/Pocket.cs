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
            if (content.Volume.Length <= Volume.Length
                && content.Volume.Width <= Volume.Width &&
                content.Volume.Height <= Volume.Height)
            {
                if (content.Volume.Length > 0                   //This is Bug I found, shouldn't be able to add
                    && content.Volume.Width > 0                 //non-existant content aka (0,0,0)
                    && content.Volume.Height > 0)
                {
                    Contents.Add(content);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        public bool Remove(Content content)
        {
            Contents.Remove(content);
            return true;
        }

        public bool Check(Content content)
        {
            bool output = Contents.Contains(content);
            return output;
        }

        public List<Content> Dump()
        {
            var swapper = new List<Content>(Contents);
            Contents.Clear();
            return swapper;
        }


    }
}
