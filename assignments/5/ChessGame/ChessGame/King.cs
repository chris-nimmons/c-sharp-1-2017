using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : IRenderable
    {
        static void Main(string[] args)
        {
            int height = 2;
            int width = 2;
            int xOffset = 1;
            int yOffset = 3;

            for (int x = xOffset; x < width + xOffset; x++)
            {
                for (int y = yOffset; y < height + yOffset; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write('X');
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
