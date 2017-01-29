﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Piece 
    {
        public int X { get; set;  }
        public int Y { get; set; }

        public char Letter { get; set; }
        public bool Visible { get; set; }


        public Piece()
        {
            Visible = true;

        }

    }
}
