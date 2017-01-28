using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesign
{
    public class Bag
    {
        public string Color { get; set; }
        public Volume Volume { get; set; }
        public decimal Weight { get; set; }
        public List<Pocket> Pockets { get; set; }
        private List<Content> Contents { get; set; }
        public Condition Condition { get; set; }
       


        public Bag(string color, decimal length, decimal height, decimal width, decimal weight, Condition condition)
        {
            Contents = new List<Content>();
            Pockets = new List<Pocket>();
            Volume = new Volume(length, height, width);
            Condition = condition;
            Color = color;
            Weight = weight;
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
        public bool AddPocket(Pocket pocket)
        {
            if (pocket.Volume.Length <= Volume.Length
                && pocket.Volume.Height <= Volume.Height
                && pocket.Volume.Width <= Volume.Width
                && pocket.Volume.Length > 0
                && pocket.Volume.Height > 0
                && pocket.Volume.Width > 0
                )
            {
                Pockets.Add(pocket);
                return true;
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
