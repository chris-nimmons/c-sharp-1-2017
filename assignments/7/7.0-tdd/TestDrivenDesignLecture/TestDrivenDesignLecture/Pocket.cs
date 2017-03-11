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
        public bool Color { get; set; }
        public Condition Condition { get; set; }
        public float Weight { get; set; }

        public Pocket(float length, float width, float height)
        {
            Contents = new List<Content>();
            Volume = new Volume(length, width, height);
        }

        public bool Add(Content content)
        {
            if (content.Volume.Width < Volume.Width
                && content.Volume.Length < Volume.Length
                && content.Volume.Height < Volume.Height)
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
            if (content == null)
            {
                return false;
            }
             else
            {
                Contents.Remove(content);
                return true;
            }
        }

        public bool Check(Content content)
        {
            if (content != null)
            {
                Contents.Contains(content);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Content> Dump(Pocket pocket)
        {
            if(pocket != null)
            {
                var swapper = new List<Content>(Contents);
                Contents.Clear();
                return swapper;
            }
            else
            {
                return false;
            }
            
        }


    }
}
