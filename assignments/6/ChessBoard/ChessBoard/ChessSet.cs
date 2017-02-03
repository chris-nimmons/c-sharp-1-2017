using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class ChessSet : IRenderable
    {
        public void Render()
        {
            for (int x = 0; x <= 20; x++)
            {
                for (int y = 0; y <= 20; y++)
                {
                    if (x == 0 || y == 0)
                    {
                        Console.SetCursorPosition(x,y);
                        Console.Write('X');
                    }
                    else if (x == 20)
                    {

                        Console.SetCursorPosition(x, y);
                        Console.Write('X');
                    }
                    else if (y == 20)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write('X');
                    }
                    else
                    {

                        Console.SetCursorPosition(x, y);
                        Console.Write(" ");

                    }
                }
            }
        }
    }
}
