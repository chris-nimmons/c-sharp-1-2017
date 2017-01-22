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
            var queen = new Queen();
            queen.letter = 'Q';
            queen.startRender();
            var castle = new Castle();
            castle.letter = 'C';
            castle.startRender();
            var king = new King();
            king.letter = 'K';
            king.startRender();
            var pawn = new Pawn();
            pawn.letter = 'P';
            pawn.startRender();
            var knight = new Knight();
            knight.letter = 'N';
            knight.startRender();
            var bishop = new Bishop();
            bishop.startRender();

            Console.ReadLine();

            var pieces = new List<Piece>();
            pieces.Add(new Piece { letter = queen.letter });
            pieces.Add(new Piece { letter = pawn.letter });
            pieces.Add(new Piece { letter = castle.letter });
            pieces.Add(new Piece { letter = king.letter });
            pieces.Add(new Piece { letter = bishop.letter });
            pieces.Add(new Piece { letter = knight.letter });

            var moves = new List<Move>();
          //  moves.Add(new Move { queen.moves });



            //for (int letter = 0; letter < 7; letter++)
            //{

            //}
            //{
            //    var piece = new Piece()
            //    {
            //    };
            //    pieces.Add(piece);
            //}

            //pieces.ForEach(Console.WriteLine);
            //Console.ReadLine();


            var cursor = new Cursor();

            //foreach (var piece in pieces)
            //{
            //    Console.SetCursorPosition(piece.X, piece.Y);
            //    Console.Write(piece.letter);
            //}


            //pieces.ForEach(Console.WriteLine);
            //Console.ReadLine();
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
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                {
                                    highlighted = piece;
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
                                    Console.Write(selection.letter);
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
                                selection.X = cursor.X;
                                selection.Y = cursor.Y;

                                Console.Write(selection.letter);

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


