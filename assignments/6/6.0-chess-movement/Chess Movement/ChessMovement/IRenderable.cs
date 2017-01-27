using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public interface IRenderable
    {
        int X { get; set; }
        int Y { get; set; }
        char Letter { get; set; }
        bool Visible { get; set; }
        List<IRenderable> GetMoves();

    }
}
