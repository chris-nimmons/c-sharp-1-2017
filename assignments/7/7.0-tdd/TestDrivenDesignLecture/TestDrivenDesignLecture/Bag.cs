﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDesignLecture
{
    public class Bag
    {
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

        public bool Add(Content content)
        {
            if (content.Volume.Length < Volume.Length
                && content.Volume.Width < Volume.Width &&
                content.Volume.Height < Volume.Height)
            {
                Contents.Add(content);
                return true;
            }
            else
            {
                return false;
            }      
            
        }

        public void Remove(Content content)
        {
            Contents.Remove(content);
        }

        public bool Check(Content content)
        {
            bool output = Contents.Contains(content);
            return output;

        }

        public List<Content> Dump()
        {
            return Contents;
        }



    }
}
