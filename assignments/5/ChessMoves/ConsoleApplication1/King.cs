using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
     class King : Piece
    {
        public void Render()
        {
            X = 3;
            Y = 3;

            for (int y = 9; y < Y+9; y++)
            {
                for (int x = 9; x < X+9; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("X");
                }
            }
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
            Console.SetCursorPosition(1, 1);
            Console.Write("---King---");
        }
    }
}


