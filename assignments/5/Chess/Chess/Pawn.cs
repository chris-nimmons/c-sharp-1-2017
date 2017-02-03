using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : Pieces
    {


        public void Render()
        {
            int X = 10;
            int Y = 10;
            int spaces = 1;

            Console.SetCursorPosition(0, 0);
            Console.Write("Pawn");

            Console.SetCursorPosition(X, Y - spaces);
            Console.Write("X");





            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }
    }
}
