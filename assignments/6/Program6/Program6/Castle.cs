using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project6.Program;

namespace Program6
{
    class Castle : Piece
    {
        public void CastlePiece()
        {
            int Width = 8;
            int Height = 5;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (y == 0)
                    {
                        Console.SetCursorPosition(10, 8);
                        Console.Write(" X X X");
                    }
                    else if (y == 1)
                    {
                        Console.SetCursorPosition(10, 9);
                        Console.Write("  XXX");

                    }
                    else if (y == 2)
                    {
                        Console.SetCursorPosition(10, 10);
                        Console.Write("XXXOXXXX");
                    }
                    else if (y == 3)
                    {
                        Console.SetCursorPosition(10, 11);
                        Console.Write("  XXX");
                    }
                    else if (y == 4)
                    {
                        Console.SetCursorPosition(10, 12);
                        Console.Write(" X X X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
            }
            Console.ReadLine();
        }
    }
}
