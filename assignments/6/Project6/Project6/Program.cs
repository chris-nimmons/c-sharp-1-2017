using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Program
    {
        static void Main(string[] args)
        {

            Renderer renderer = new Renderer();

            var cursor = new Cursor();

            Pawn pawn = new Pawn();
            Pawn one = new Pawn();
            King two = new King();
            Queen queen = new Queen();


            List<Piece> pieces = new List<Piece>();

            one.X = 4;
            one.Y = 0;

            two.X = 2;
            two.Y = 0;

            pawn.X = 1;
            pawn.Y = 0;

            queen.X = 3;
            queen.Y = 0;
            queen.Visible = true;

            pieces.Add(pawn);
            pieces.Add(one);
            pieces.Add(two);
            pieces.Add(queen);

            renderer.Render(pieces);

            Piece selection = null;
            foreach (var piece in pieces)
            {
                Console.SetCursorPosition(piece.X, piece.Y);
            }

            Console.SetCursorPosition(cursor.X, cursor.Y);
            bool running = true;
            while (running)
            {
                var info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    case ConsoleKey.UpArrow:
                        cursor.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        cursor.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        cursor.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        cursor.X++;
                        break;
                    case ConsoleKey.Enter:
                        Piece highlighted = null;
                        foreach (var piece in pieces)
                        {
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;
                            }
                        }
                        if (highlighted != null)
                        {
                            if (selection != null)
                            {
                                if (highlighted == selection)
                                {
                                    Console.Write(selection);
                                    selection = null;
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                selection = highlighted;
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            if (selection != null)
                            {
                                Console.Write(selection);
                                selection.X = cursor.X;
                                selection.Y = cursor.Y;

                                selection = null;
                            }
                        }
                        break;
                }
                if (cursor.X < 0)
                {
                    cursor.X = 0;
                }
                if (cursor.Y < 0)
                {
                    cursor.Y = 0;
                }
                Console.SetCursorPosition(cursor.X, cursor.Y);
            }

        }
    }
    public class Cursor
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
