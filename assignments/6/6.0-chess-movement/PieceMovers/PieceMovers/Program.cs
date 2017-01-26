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
            //var welcome = new WelcomeScreen();

            //if (welcome.Visible)
            //{
            //    renderer.Render(welcome);

            //} Console.ReadLine();

            var moves = new List<Move>();
            var pieces = new List<Piece>();

            pieces.Add(new Queen { X = 3, Y = 0 });
            pieces.Add(new Bishop { X = 1, Y = 0 });
            pieces.Add(new Castle { X = 0, Y = 0 });
            pieces.Add(new King { X = 4, Y = 0 });
            pieces.Add(new Pawn { X = 1, Y = 1 });
            pieces.Add(new Knight { X = 2, Y = 0 });

            foreach (var piece in pieces)
            {
                renderer.Render(piece);
            }

            var cursor = new Cursor();
            Console.SetCursorPosition(cursor.X, cursor.Y);
            bool running = true;
            while (running)
            {
                Console.SetCursorPosition(cursor.X, cursor.Y);

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
                                    Console.Clear();
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
                                selection.Visible = false;
                                moves = selection.Moves();

                                foreach (var move in moves)
                                {
                                    if (move.X < 8 && move.Y < 8)
                                    {
                                        if (move.X >= 0 && move.Y >= 0)
                                        {
                                            renderer.Render(move);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (selection != null)

                                selection.Visible = true;
                            foreach (var move in moves)
                            {
                                if (cursor.X == move.X && cursor.Y == move.Y)
                                {
                                    Console.SetCursorPosition(selection.X, selection.Y);
                                    Console.Write(' ');
                                    selection.X = cursor.X;
                                    selection.Y = cursor.Y;
                                    Console.SetCursorPosition(selection.X, selection.Y);
                                    Console.Write(selection.Letter);
                                    Console.ResetColor();
                                    selection.Visible = true;
                                    selection = null;
                                    Console.Clear();
                                    foreach (var piece in pieces)
                                    {
                                        piece.Visible = true;
                                        renderer.Render(piece);
                                    }
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
                        foreach (var piece in pieces)
                        {
                            piece.Visible = true;
                            Console.ForegroundColor = ConsoleColor.White;
                            renderer.Render(piece);
                        }
                        break;
                }
            }
        }

    }
}


