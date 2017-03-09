using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{

    class Program
    {
        public static void Main(string[] args)
        {
            var renderables = new List<IRenderable>();

            var renderer = new Renderer();

            var moves = new List<Move>();

            var board = new Board();
            board.Initialize();

            var cursor = new Cursor();
            Piece selection = null;

            foreach (var piece in board.Pieces)
            {

                renderer.Render(piece);
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

                        foreach (var piece in board.Pieces)
                        {
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;

                            }
                        }

                        //if we do have a selection
                        if (highlighted != null)
                        {
                            if (selection != null)
                            {

                                if (highlighted == selection)
                                {
                                    selection.Visible = true;
                                    //deselecting
                                    selection = null;

                                    moves.Clear();
                                }
                                else
                                {
                                    //do nothing
                                }
                            }
                            else
                            {
                                selection = highlighted;
                                selection.Visible = false;
                                moves = selection.GetMoves();
                               

                                //selection.GetMoves();
                                //moves.AddRange(selection.GetMoves());

                            }


                        }
                        else
                        {
                            //if ther is a piece selected
                            if (selection != null)
                            {
                                foreach (var move in moves)
                                {
                                    if (cursor.X == move.X && cursor.Y == move.Y)
                                    {

                                        selection.Visible = true;
                                        selection.X = cursor.X;
                                        selection.Y = cursor.Y;
                                        selection = null;
                                        moves.Clear();
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                }

                if (cursor.X < 0)
                {
                    cursor.X = 0;
                }
                if (cursor.X > 7)
                {
                    cursor.X = 7;
                }

                if (cursor.Y < 0)
                {
                    cursor.Y = 0;
                }

                if (cursor.Y > 7)
                {
                    cursor.Y = 7;
                }
                Console.CursorVisible = false;
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
                Console.CursorVisible = true;


            }
        }
    }

    public class Cursor
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
