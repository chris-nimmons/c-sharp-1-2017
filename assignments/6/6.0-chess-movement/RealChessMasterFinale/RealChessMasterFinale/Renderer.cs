using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    public class Renderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(IRenderable renderable)
        {
            if (renderable.Visible == true)
            {
                Console.SetCursorPosition(renderable.X, renderable.Y);
                Console.Write(renderable.Index);
            }


        }

        public void Render(Move moves)
        {
            if (moves.X >= 0 && moves.X <= 7
                && moves.Y >= 0 && moves.Y <= 7)
            {
                Console.SetCursorPosition(moves.X, moves.Y);
                Console.Write(moves.Index);
            }

        }

    }
}
