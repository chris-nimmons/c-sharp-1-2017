using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public class Move : IRenderable
    {

        public int X { get; set; }
        public int Y { get; set; }
        public bool Visible { get; set; }
        public char Index { get; set; }

        public Move()
        {
            
            Index = '#';

        }


    }
}

