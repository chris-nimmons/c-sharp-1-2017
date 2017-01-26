using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealChessMasterFinale
{
    class Program
    {
        static void Main(string[] args)
        {
            var cursor = new Cursor();
            var renderer = new Renderer();

            var board = new Board();
            board.Initialize();


            var moves = new List<Move>();


            foreach (var renderable in board.Renderables)
            {
                renderer.Render(renderable);
            }

            Piece selection = null;


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

                        foreach (var piece in board.Pieces)
                        {
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;
                                break;
                            }
                        }

                        if (highlighted != null)
                        {

                            if (selection != null)
                            {
                                //get moves here?  Nah son


                                if (highlighted == selection)
                                {

                                    selection.Visible = true;
                                    //deselecting
                                    selection = null;
                                    highlighted = null;
                                    moves.Clear();

                                }

                                else
                                {
                                    break;
                                    selection.Visible = true;
                                    selection = null;
                                    highlighted = null;
                                    moves.Clear();

                                }
                            }

                            //if we dont have a selection
                            else
                            {
                                //select the current piece the cursor is over
                                selection = highlighted;
                                selection.Visible = false;
                                moves = selection.GetMoves();

                            }
                        }

                        //if the cursor is not over a piece
                        else
                        {

                            //if there is a piece selected
                            if (selection != null)
                            {
                                break;
                                //moving Ninja Style
                                selection.Visible = true;
                                selection.X = cursor.X;
                                selection.Y = cursor.Y;

                                selection = null;
                                moves.Clear();
                            }
                        }

                        break;
                }

                //make it so the cursor can not go off the board
                if (cursor.X < 0)
                {
                    cursor.X = 7;
                }
                if (cursor.Y < 0)
                {
                    cursor.Y = 7;
                }
                if (cursor.X > 7)
                {
                    cursor.X = 0;
                }
                if (cursor.Y > 7)
                {
                    cursor.Y = 0;
                }

                renderer.Clear();

                foreach (var move in moves)
                {
                    renderer.Render(move);
                }


                foreach (var piece in board.Pieces)
                {
                    renderer.Render(piece);
                }

                Console.SetCursorPosition(cursor.X, cursor.Y);

            }
            //Console.ReadLine();
        }
    }

    public class Cursor
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
