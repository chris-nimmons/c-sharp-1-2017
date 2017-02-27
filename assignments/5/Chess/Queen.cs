﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public static List<Move> GetMoves()
        {
            
        }
        public void Render()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(X + i, Y - i);
                Console.Write("x");
                Console.SetCursorPosition(X + i, Y + i);
                Console.Write("x");
                Console.SetCursorPosition(X - i, Y + i);
                Console.Write("x");
                Console.SetCursorPosition(X - i, Y - i);
                Console.Write("x");
                //Console.SetCursorPosition(10, 10);
                //Console.Write("o");
                Console.SetCursorPosition(X + i, Y);
                Console.Write("x");
                Console.SetCursorPosition(X, Y + i);
                Console.Write("x");
                Console.SetCursorPosition(X - i, Y);
                Console.Write("x");
                Console.SetCursorPosition(X, Y - i);
                Console.Write("x");
                //Console.SetCursorPosition(0, 22);
                //Console.WriteLine("Queen");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
