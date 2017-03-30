using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public interface IRenderable
    {
        bool Visible { get; set; }
        char Letter { get; set; }

        int X { get; set; }
        int Y { get; set; }
    }
}
