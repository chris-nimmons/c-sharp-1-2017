using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises1_19
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            var pieces = new List<Piece>();
            for (int i = 0; i < random.Next(5, 10); i++)
            {
                var piece = new Piece()
                {
                    Index = i,
                    X = random.Next(0, 21),
                    Y = random.Next(0, 21)
                };
                pieces.Add(piece);
            }

            var cursor = new Cursor();

            Piece selection = null;
            foreach (var piece in pieces)
            {
                Console.SetCursorPosition(piece.X, piece.Y);
                Console.Write(piece.Index);
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
                            // if the cursor is over a piece
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;
                            }
                        }

                        if (highlighted != null)
                        {
                            //if we have a selection
                            if (selection != null)
                            {
                                //if the piece the cursor is over is same as the selection
                                if (highlighted == selection)
                                {
                                    Console.Write(selection.Index);

                                    // deselecting
                                    selection = null;

                                }
                                // if the piece the cursor is over is not the same as the selection
                                else
                                {
                                    //do nothing
                                }
                            }
                            // if we dont have a selection
                            else
                            {
                                selection = highlighted;
                                Console.Write(" ");

                            }
                        }
                        // if the cursor is not over a piece
                        else
                        {
                            //if there is a piece selected
                            if (selection != null)
                            {
                                //moving
                                Console.Write(selection.Index);
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
    public class Piece
    {
        public int Index { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}


