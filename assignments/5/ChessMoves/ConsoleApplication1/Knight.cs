using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Knight : Piece
    {

        public void Render()
        {
            int X = 10;
            int Y = 10;
            Console.SetCursorPosition(X + 2, Y - 2);
            Console.Write("X");
            Console.SetCursorPosition(X + 2, Y + 2);
            Console.Write("X");
            Console.SetCursorPosition(X - 2, Y - 2);
            Console.Write("X");
            Console.SetCursorPosition(X - 2, Y + 2);
            Console.Write("X");

            Console.SetCursorPosition(X + 5, Y - 1);
            Console.Write("X");
            Console.SetCursorPosition(X + 5, Y + 1);
            Console.Write("X");
            Console.SetCursorPosition(X - 5, Y - 1);
            Console.Write("X");
            Console.SetCursorPosition(X - 5, Y + 1);
            Console.Write("X");




            Console.SetCursorPosition(10, 10);
            Console.Write("O");
            Console.SetCursorPosition(0, 1);
            Console.Write("---Knight---");
        }
    }
}

