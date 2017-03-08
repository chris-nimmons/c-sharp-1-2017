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

            Board board = new Board();

            var pieces = board.GetPieces();

            var moves = new List<Move>();

            ///DONE: pass blank list of moves in to Render
            renderer.Render(pieces, moves);

            Piece selectedPiece = null; 

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

                        Piece highlightedPiece = null;

                        highlightedPiece = pieces.FirstOrDefault(p => p.X == cursor.X && p.Y == cursor.Y);

                        if (highlightedPiece != null)
                        {
                            if (selectedPiece != null)
                            {
                                if (highlightedPiece == selectedPiece)
                                {
                                    selectedPiece.Visible = true;
                                    selectedPiece = null;
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                // Entering selection mode
                                selectedPiece = highlightedPiece;
                                selectedPiece.Visible = false;

                                //TODO: Get the list of moves from selectedPiece and store it in the moves variable.  
                                moves = selectedPiece.GetMoves();
                                
                               
                            }
                        }
                        else
                        {
                            if (selectedPiece != null)
                            {

                                bool isMovedAllowed = board.IsMoveAllowed(selectedPiece, cursor);

                                if (isMovedAllowed) //  You don't need the '== true' variable is a boolean.
                                {
                                    //  Now update the selected piece cursor location.
                                    selectedPiece.X = cursor.X;
                                    selectedPiece.Y = cursor.Y;
                                    selectedPiece.Visible = true;
                                    selectedPiece = null;
                                    moves.Clear();
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

                if (cursor.X > 7)
                {
                    cursor.X = 7;
                }
                if (cursor.Y > 7)
                {
                    cursor.Y = 7;
                }

                renderer.Clear();
                //TODO: Pass list of moves from the selected piece into Render method.
                renderer.Render(pieces, moves);

                Console.SetCursorPosition(cursor.X, cursor.Y);
            }
        }

    }
    public class Cursor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static implicit operator Cursor(List<Cursor> v)
        {
            throw new NotImplementedException();
        }
    }
}
