using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceMovers
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Piece selection = null;

            var pieces = new List<Piece>();

            pieces.Add(new Queen { X = 3, Y = 0, Visible = true });
            pieces.Add(new Bishop { X = 1, Y = 0, Visible = true });
            pieces.Add(new Castle { X = 0, Y = 0, Visible = true });
            pieces.Add(new King { X = 4, Y = 0, Visible = true });
            pieces.Add(new Pawn { X = 1, Y = 1, Visible = true });
            pieces.Add(new Knight { X = 2, Y = 0, Visible = true });

            foreach (var piece in pieces)
            {
                renderer.Render(piece);
            }

            var cursor = new Cursor();
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
                                {
                                    highlighted = piece;
                                    foreach (var move in pieces)
                                    {
                                        renderer.Render(move);
                                    }
                                    break;
                                }
                            }
                        }
                        if (highlighted != null)
                        {
                            if (selection != null)
                            {
                                if (highlighted == selection)
                                {
                                    Console.Write(selection.Letter);
                                    //deselecting
                                    selection = null;
                                }
                                else
                                {
                                    //do nothing
                                }
                            }
                            else
                            {
                                //selecting
                                selection = highlighted;
                                Console.Write("#");

                            }
                        }
                        else
                        {
                            if (selection != null)
                            {
                                //moving
                                Console.SetCursorPosition(selection.X, selection.Y);
                                Console.Write(' ');
                                selection.X = cursor.X;
                                selection.Y = cursor.Y;
                                Console.SetCursorPosition(selection.X, selection.Y);
                                Console.Write(selection.Letter);
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


}


