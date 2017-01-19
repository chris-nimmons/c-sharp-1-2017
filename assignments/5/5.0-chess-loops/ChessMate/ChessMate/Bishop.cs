using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
   public class Bishop : Piece
    {

        public void Render()
        {
            x = 10;
            y = 10;
            moves = 10;

            for (int i = 0; i <= moves; i++)
            {

                Console.SetCursorPosition(x, y);
                Console.Write("X");

                Console.SetCursorPosition(x - i, y + i);
                Console.Write("X");

                Console.SetCursorPosition(x + i, y - i);
                Console.Write("X");

                Console.SetCursorPosition(x + i, y + i);
                Console.Write("X");

                Console.SetCursorPosition(x - i, y - i);
                Console.Write("X");

            }
            Console.SetCursorPosition(10, 10);
            Console.Write("O");
            Console.SetCursorPosition(7, 0);
            Console.Write("Bishop");
        }
    }
}
