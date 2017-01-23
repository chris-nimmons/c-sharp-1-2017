using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    class Program 
    {
        static void Main(string[] args)
        {
            var cursor = new Cursor();
            var board = new Board();
            board.PlacePiece();
           // var pieces = new Board();
            

            var pieces = new List<Piece>();
            
            //var moves = new Move();
            
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
                        foreach (var piece in pieces)
                        {
                            //if the cursor is over a piece
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;
                                
                            }
                        }

                        //if we have a selection
                        if (highlighted != null)
                        {

                            if (selection != null)
                            {
                                

                                //if the piece the cursor is over is the same as the selection
                                if (highlighted == selection)
                                {
                                    Console.Write(selection.Index);

                                    //deselecting
                                    selection = null;

                                }
                                //if the piece the cursor is over is not the same as the selection
                                else
                                {
                                    //do nothing
                                }

                            }
                            //if we dont have a selection
                            else
                            {

                                //select the current piece the cursor is over
                                selection = highlighted;
                                Console.Write(selection.Index);

                            }
                        }

                        //if the cursor is not over a piece
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

                //make it so the cursor can not go off the board
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
