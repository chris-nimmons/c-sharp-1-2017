using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    public class WelcomeScreen : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Letter { get; set; }
        public bool Visible { get; set; }
        public void Welcome()
        {
            Visible = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            string str1 = "Jeff ChessMoves vs1.0";
            Console.SetCursorPosition((Console.WindowWidth - str1.Length) / 2, Console.CursorTop);
            Console.WriteLine(str1);
            string str2 = "Known issues documented in";
            Console.SetCursorPosition((Console.WindowWidth - str2.Length) / 1, Console.CursorTop);
            Console.WriteLine(str2);
            Console.ResetColor();
        }
    }
}

