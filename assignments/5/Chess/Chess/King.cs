using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : Pieces
    {


        public void Render()
        {
            int X = 10;
            int Y = 10;
            int spaces = 1;


            Console.Write("King");

            for (int a = 0; a < X + spaces; a++)
            {
                for (int b = 0; b < Y + spaces; b++)
                {

                    Console.SetCursorPosition(X + spaces, Y);
                    Console.Write("X");

                    Console.SetCursorPosition(X - spaces, Y);
                    Console.Write("X");

                    Console.SetCursorPosition(X, Y + spaces);
                    Console.Write("X");

                    Console.SetCursorPosition(X, Y - spaces);
                    Console.Write("X");

                    Console.SetCursorPosition(X - spaces, Y + spaces);
                    Console.Write("X");

                    Console.SetCursorPosition(X + spaces, Y - spaces);
                    Console.Write("X");

                    Console.SetCursorPosition(X + spaces, Y + spaces);
                    Console.Write("X");

                    Console.SetCursorPosition(X - spaces, Y - spaces);
                    Console.Write("X");
                }
            }

            Console.SetCursorPosition(10, 10);
            Console.Write("O");
        }




    }

}


