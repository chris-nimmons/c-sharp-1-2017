using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRenderable> renderables = new List<IRenderable>();
            Renderer renderer = new Renderer();

            List<IChessPiece> pieces = new List<IChessPiece>();


            pieces.Add(new Knight() { X = 9, Y = 20 });
            pieces.Add(new Knight() { X = 14, Y = 20 });
            pieces.Add(new Pawn() { X = 8, Y = 19 });
            pieces.Add(new Pawn() { X = 9, Y = 19 });
            pieces.Add(new Pawn() { X = 10, Y = 19 });
            pieces.Add(new Pawn() { X = 11, Y = 19 });
            pieces.Add(new Pawn() { X = 12, Y = 19 });
            pieces.Add(new Pawn() { X = 13, Y = 19 });
            pieces.Add(new Pawn() { X = 14, Y = 19 });
            pieces.Add(new Pawn() { X = 15, Y = 19 });
            pieces.Add(new King() { X = 11, Y = 20 });
            pieces.Add(new Queen() { X = 12, Y = 20 });
            pieces.Add(new Rook() { X = 8, Y = 20 });
            pieces.Add(new Rook() { X = 15, Y = 20 });
            pieces.Add(new Bishop() { X = 10, Y = 20 });
            pieces.Add(new Bishop() { X = 13, Y = 20 });

            //piece is a renderable, so going to add it to renderer
            foreach (IChessPiece piece in pieces)
            {
                renderables.Add(piece);
            }
            renderer.Render(renderables);

            Cursor cursor = new Cursor();
            IChessPiece selection = null;
            Console.SetCursorPosition(cursor.X, cursor.Y);

            //large chunk of code dealing with controls and movements made with the help of Chris Nimmons
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
                        IChessPiece highlighted = null;

                        foreach (IChessPiece piece in pieces)
                        {
                            if (cursor.X == piece.X && cursor.Y == piece.Y)
                            {
                                highlighted = piece;
                                selection = piece;
                                //break;
                            }
                        }

                        if (highlighted != null)
                        {
                            //if we have a selection
                            if (selection != null)
                            {
                                //if the piece cursor is over the same as the selection
                                if (highlighted == selection)
                                {
                                    //get all of the moves for that chess piece
                                    List<Move> movesListForChessPieces = selection.GetMoves();

                                    foreach (Move move in movesListForChessPieces)
                                    {

                                        //move.Render();
                                        renderables.Add(move);
                                    }
                                    renderer.Render(renderables);

                                    Console.Write(" "); //selection.Index
                                                        //deselecting
                                    selection = null;

                                    break;
                                }
                                else
                                {
                                    //do nothing
                                }
                            }
                            //if we have a slection
                            else
                            {
                                //select the current piece the cursor is over

                                selection = highlighted;
                                Console.Write(" ");
                            }
                        }
                        //if there is not pice below the cursor
                        else
                        {
                            //if there is a peice selected
                            if (selection != null)
                            {
                                //moving
                                Console.Write("X");

                                selection.X = cursor.X;
                                selection.Y = cursor.Y;


                                break;
                            }
                            break;


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

        public class Cursor
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Move : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Move(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("X");
            }
        }

        public interface IChessPiece : IRenderable
        {
            int Index { get; set; }
            int X { get; set; }
            int Y { get; set; }

            List<Move> GetMoves();
        }

        public class Knight : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 2; i++)
                {
                    

                    possibleMoves.Add(new Move(X - 1, Y - 3));
                    //possibleMoves.Add(new Move(X - 1, Y + 3));
                    possibleMoves.Add(new Move(X + 1, Y - 3));
                    //possibleMoves.Add(new Move(X + 3, Y + 1));
                    possibleMoves.Add(new Move(X + 3, Y - 1));
                    //possibleMoves.Add(new Move(X - 3, Y + 1));
                    possibleMoves.Add(new Move(X - 3, Y - 1));

                }

                return possibleMoves;
            }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("k");
            }

        }

        public class Pawn : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 2; i++)
                {
                    possibleMoves.Add(new Move(X, Y - 1));
                }

                return possibleMoves;
            }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("P");

            }
        }

        public class King : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 2; i++)
                {
                    possibleMoves.Add(new Move(X + i, Y));
                    //possibleMoves.Add(new Move(X, Y + i));
                    possibleMoves.Add(new Move(X, Y - i));
                    possibleMoves.Add(new Move(X - i, Y));
                    //possibleMoves.Add(new Move(X - i, Y + i));
                    //possibleMoves.Add(new Move(X + i, Y + i));
                    possibleMoves.Add(new Move(X + i, Y - i));
                    possibleMoves.Add(new Move(X - i, Y - i));
                }

                return possibleMoves;
            }


            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("K");
            }
        }

        public class Queen : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 8; i++)
                {
                    possibleMoves.Add(new Move(X + i, Y));
                    //possibleMoves.Add(new Move(X, Y + i));
                    possibleMoves.Add(new Move(X, Y - i));
                    possibleMoves.Add(new Move(X - i, Y));
                    //possibleMoves.Add(new Move(X - i, Y + i));
                    //possibleMoves.Add(new Move(X + i, Y + i));
                    possibleMoves.Add(new Move(X + i, Y - i));
                    possibleMoves.Add(new Move(X - i, Y - i));
                }
                return possibleMoves;

            }
            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("Q");
            }
        }

        public class Rook : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 8; i++)
                {
                    possibleMoves.Add(new Move(X + i, Y));
                    //possibleMoves.Add(new Move(X, Y + i));
                    possibleMoves.Add(new Move(X, Y - i));
                    possibleMoves.Add(new Move(X - i, Y));
                }
                return possibleMoves;
            }
            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("R");
            }
        }

        public class Bishop : IChessPiece, IRenderable
        {
            public int Index { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public List<Move> GetMoves()
            {
                List<Move> possibleMoves = new List<Move>();
                for (int i = 0; i < 8; i++)
                {
                    //possibleMoves.Add(new Move(X - i, Y + i));
                    //possibleMoves.Add(new Move(X + i, Y + i));
                    possibleMoves.Add(new Move(X + i, Y - i));
                    possibleMoves.Add(new Move(X - i, Y - i));
                }
                return possibleMoves;
            }
            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("B");

            }
        }

        public class Renderer
        {
            public void Render(List<IRenderable> renderables)
            {
                foreach (IRenderable renderable in renderables)
                {
                    renderable.Render();
                }
            }
        }

        public interface IRenderable
        {
            void Render();
        }
    }
}


