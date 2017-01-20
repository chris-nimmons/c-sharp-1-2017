using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public void Render()
        {
            for (int X = 0; X < Length; X++)
            {
                Console.SetCursorPosition(Y, X);
                Console.Write("x");
                Console.SetCursorPosition(0, 1);
                Console.Write("o");
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Pawn");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
