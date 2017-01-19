using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Knight : Pieces
    {



        public void Render()
        {
            int X = 10;
            int Y = 10;
            

            Console.SetCursorPosition(0, 0);
            Console.Write("Knight");

            Console.SetCursorPosition(X + 2, Y + 1);
            Console.Write("X");

            Console.SetCursorPosition(X + 1, Y + 2);
            Console.Write("X");

            Console.SetCursorPosition(X - 1, Y + 2);
            Console.Write("X");

            Console.SetCursorPosition(X - 2, Y + 1);
            Console.Write("X");

            Console.SetCursorPosition(X - 2, Y - 1);
            Console.Write("X");

            Console.SetCursorPosition(X - 1, Y - 2);
            Console.Write("X");

            Console.SetCursorPosition(X + 1, Y - 2);
            Console.Write("X");

            Console.SetCursorPosition(X + 2, Y - 1);
            Console.Write("X");

            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }
    }
}
