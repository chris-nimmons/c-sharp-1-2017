using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public void Render()
        {
            for (int row = X; row < Length + Y; row++)
            {
                for (int col = Y; col < Width + X; col++)
                {
                    Console.SetCursorPosition(row, col);
                    Console.Write("x");
                    Console.SetCursorPosition(1, 1);
                    Console.Write("o");
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("King");
                }

            }
            Console.ReadLine();
            Console.Clear();
        }

    }
}
