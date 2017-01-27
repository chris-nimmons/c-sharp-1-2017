using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class Renderer
    {
        public void Render(List<IRenderable> renderables)
        {
            foreach (IRenderable renderable in renderables)
            {
                if (renderable.Visible)
                {

                    Console.SetCursorPosition(renderable.X, renderable.Y);
                    Console.Write(renderable.Letter);
                }

            }
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
