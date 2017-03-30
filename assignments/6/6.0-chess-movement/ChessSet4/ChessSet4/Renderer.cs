using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
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
                    Console.Write(renderable.Letter);
                }
                //renderable.Render();
        }

        public void Render(Move move)
        {
            if (move.X >= 0 && move.X <= 7 && move.Y >= 0 && move.Y <= 7)
            {
                Console.SetCursorPosition(move.X, move.Y);
                Console.Write(move.Letter);
            }
        }

        
    }
    
}
