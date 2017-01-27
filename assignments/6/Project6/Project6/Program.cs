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
            Cursor cursor = new Cursor();
            var pieces = new List<Piece>();
            var king = new King() { X = 3, Y = 0 };
            var queen = new Queen() { X = 4, Y = 0 };
            var bishop = new Bishop() { X = 2, Y = 0 };
            var bishop2 = new Bishop() { X = 5, Y = 0 };
            var knight = new Knight() { X = 1, Y = 0 };
            var castle = new Castle() { X = 0, Y = 0 };
            var knight2 = new Knight() { X = 6, Y = 0 };
            var castle2 = new Castle() { X = 7, Y= 0};

            var kingBlack = new King() { X = 4, Y = 7 };
            var queenBlack = new Queen() { X = 3, Y = 7};
            var bishopBlack = new Bishop() { X = 2, Y = 7 };
            var bishop2Black = new Bishop() { X = 5, Y = 7 };
            var knightBlack = new Knight() { X = 1, Y = 7 };
            var castleBlack = new Castle() { X = 0, Y = 7 };
            var knight2Black = new Knight() { X = 6, Y = 7 };
            var castle2Black = new Castle() { X = 7, Y = 7 };

            var pawns = new List<Pawn>();

            for (int x = 0; x < 8; x++)
            {
                var pawn = new Pawn() { Y = 1, X = x };
                pieces.Add(pawn);

                pawn = new Pawn() { Y = 6, X = x };
                pieces.Add(pawn);
            }

            pieces.Add(castle2Black);
            pieces.Add(knightBlack);
            pieces.Add(castleBlack);
            pieces.Add(bishop2Black);
            pieces.Add(bishopBlack);
            pieces.Add(knightBlack);
            pieces.Add(knight2Black);
            pieces.Add(kingBlack);
            pieces.Add(queenBlack);

            pieces.Add(castle2);
            pieces.Add(knight);
            pieces.Add(castle);
            pieces.Add(bishop2);
            pieces.Add(bishop);
            pieces.Add(knight);
            pieces.Add(knight2);
            pieces.Add(king);
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
                                    Console.Write(selection.Letter);
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
                                Console.Write(selection.Letter);
                                selection.X = cursor.X;
                                selection.Y = cursor.Y;

                                selection = null;
                            }
                        }
                        break;
                }
                if (cursor.X < 0 || cursor.Y < 0)
                {
                    cursor.X = 0;
                    cursor.Y = 0;
                }
                if (cursor.X > 7 || cursor.Y < 0)
                {
                    cursor.X = 0;

                }
                if (cursor.X > 7)
                {
                    cursor.X = 0;
                }
                if (cursor.X < 0 || cursor.Y > 7)
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

