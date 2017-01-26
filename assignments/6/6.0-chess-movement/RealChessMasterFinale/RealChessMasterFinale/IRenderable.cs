using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public interface IRenderable
    {
        int X { get; set; }
        int Y { get; set; }
        bool Visible { get; set; }
        char Index { get; set; }

    }
}
