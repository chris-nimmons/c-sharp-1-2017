using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public interface IRenderable

    {
        bool Visible { get; set; }
        int X { get; set; }
        int Y { get; set; }
        char Letter { get; set; }

    }
}
