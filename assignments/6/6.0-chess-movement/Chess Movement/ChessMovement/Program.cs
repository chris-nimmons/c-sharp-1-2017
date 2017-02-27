using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* CITATION
 * Program was written by Chris with class participation
 */

namespace ChessMovement
{
    class Program
    {
        static void Main()
        {
            Renderer renderer = new Renderer();
            List<IRenderable> renderables = new List<IRenderable>();
            List<IRenderable> moves = new List<IRenderable>();
            Move choice = new Move();

            var king = new King() { X = 4, Y = 0 };
            var queen = new Queen() { X = 3, Y = 0 };
            var bishop = new Bishop() { X = 2, Y = 0 };
            var castle = new Castle() { X = 0, Y = 0 };
            var pawn = new Pawn() { X = 5, Y = 1 };
            var knight = new Knight() { X = 1, Y = 0 };

            renderables.Add(queen);
            renderables.Add(king);
            renderables.Add(bishop);
            renderables.Add(castle);
            renderables.Add(pawn);
            renderables.Add(knight);

            var cursor = new Cursor();
            IRenderable selection = null;

            renderer.Render(renderables);

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

                        IRenderable highlighted = null;
                        foreach (var piece in renderables)
                        {
                            //if the cursor is over a piece
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
                                //if the piece the cursor is over is the same as the selection
                                if (highlighted == selection)
                                {
                                    selection.Visible = true;
                                    moves.Clear();
                                    //deselecting
                                    selection = null;
                                }
                                //if the piece the cursor is over is not the same as selection
                                else
                                {
                                    //do nothing
                                }

                            }
                            //if we have a selection
                            else
                            {
                                //selecting
                                selection = highlighted;
                                selection.Visible = false;
                               
                                moves = selection.GetMoves();
 
                                
                            }

                        }
                        //if the cursor is not over a place
                        else
                        {
                            //if there is a piece selected
                            if (selection != null)
                            {

                                foreach (var move in moves)
                                {
                                    if (cursor.X == move.X && cursor.Y == move.Y)
                                    {
                                     selection.X = cursor.X;
                                     selection.Y = cursor.Y;

                                selection.Visible = true;

                                moves.Clear();
                                selection = null;
                                break;
                                    }
                                    else
                                    {
                                        //selection.Visible = false;
                                    }
                                }
                                //moving



                            }
                            
                        }
                        break;
                }

                if (cursor.X <= 0)
                {
                    cursor.X = 0;
                }

                if (cursor.Y <= 0)
                {
                    cursor.Y = 0;
                }
                if (cursor.X >= 7)
                {
                    cursor.X = 7;
                }
                if (cursor.Y >= 7)
                {
                    cursor.Y = 7;
                }


                renderer.Clear();
                renderer.Render(renderables);
                renderer.Render(moves);
                Console.SetCursorPosition(cursor.X, cursor.Y);

            }

        }
    }
}

