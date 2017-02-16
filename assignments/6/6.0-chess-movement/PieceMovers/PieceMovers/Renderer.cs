using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class Renderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(IRenderable renderable)
        {
            if (renderable.Visible)
            {
                Console.SetCursorPosition(renderable.X, renderable.Y);
                Console.Write(renderable.Letter);
            }
            else
            {
            }
        }
    }
}
