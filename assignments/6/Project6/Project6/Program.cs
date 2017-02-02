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

            renderer.Render(pieces);

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

                        highlighted = pieces.Where(p => cursor.X == p.X && cursor.Y == p.Y).Select(p => p).FirstOrDefault();

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
                                    // Have selected another piece.
                                    selection = null;
                                    selection = highlighted;
                                    
                                }
                            }
                            else
                            {

                                // Entering selection mode
                                selection = highlighted;

                            }
                        }
                        else
                        {
                            if (selection != null)
                            {

                                bool isMovedAllowed = board.IsMoveAllowed(selection, cursor);
                                if (isMovedAllowed == true)
                                {


                                    selection.X = cursor.X;
                                    selection.Y = cursor.Y;
                                    Console.Write(selection.Letter);


                                }
                                else if (isMovedAllowed == false)
                                {
                                    cursor.X = 0;
                                    cursor.Y = 0;
                                  
                                }

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

        public static implicit operator Cursor(List<Cursor> v)
        {
            throw new NotImplementedException();
        }
    }
}
