using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
    public class Pocket
    {
        private List<Content> Contents { get; set; }
        public Volume Volume { get; set; }
        public decimal Value { get; set; }

        public Pocket(decimal length, decimal height, decimal width)
        {
            Contents = new List<Content>();
            Volume = new Volume(length, height, width);
        }

        public bool Add(Content content)
        {
            if (content.Volume.Length <= Volume.Length
                && content.Volume.Height <= Volume.Height
                && content.Volume.Width <= Volume.Width
                && content.Volume.Length > 0
                && content.Volume.Height > 0
                && content.Volume.Width > 0
                                )
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
