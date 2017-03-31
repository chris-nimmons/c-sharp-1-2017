using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Bag
    {
        public float Length { get; set; }
        public string Color { get; set; }
        public Volume Volume { get; set; }
        public float Weight { get; set; }
        public List<Pocket> Pockets { get; set; }
        private List<Content> Contents { get; set; }        
        public Condition Condition { get; set; }
        

        public Bag(float length, float width, float height)
        {
            Contents = new List<Content>();
            Pockets = new List<Pocket>();
            Volume = new Volume(length, width, height);
        }

        public bool Add(Content content, Content content2)
        {
            
            if (content.Volume.Length < Volume.Length
                && content.Volume.Width < Volume.Width &&
                content.Volume.Height < Volume.Height)
            {
                if (content.Volume.Length + content2.Volume.Length > Volume.Length || content.Volume.Width + content2.Volume.Width > Volume.Width ||
                content.Volume.Height + content2.Volume.Height > Volume.Height)
                {
                    Contents.Add(content);
                    
                    return false;
                }
                else
                {
                    Contents.Add(content);
                    Contents.Add(content2);
                    return true;
                }
               
            }
            else
            {
                return false;
            }      
            
        }

        public bool Remove(Content content)
        {
            if (content.Volume.Length < Volume.Length
                && content.Volume.Width < Volume.Width &&
                content.Volume.Height < Volume.Height)
            {
                Contents.Remove(content);
                return true;
            }
            
            else
            {
                return false;
            }
           
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
