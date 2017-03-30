using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//make sure to render everyhting at the end


namespace ChessSet4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRenderable> renderables = new List<IRenderable>();
            List<Move> possibleMoves = new List<Move>();

            Cursor cursor = new Cursor();
            Renderer renderer = new Renderer();


            Board board = new Board();

            board.Initialize();


            foreach (IRenderable renderable in board.Renderables)
            {
                renderer.Render(renderable);
            }

            ChessPiece selection = null;
           
            Console.SetCursorPosition(cursor.X, cursor.Y);
            //Move move = new Move(1,2); //GAAAAAAAAAAHHHHHHHHHHHHH

            bool running = true;
            while(running)
            {
                var info = Console.ReadKey(true);
                switch(info.Key)
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
                        ChessPiece highlighted = null; //IChessPiece highlighted = null;
                        
                        foreach (ChessPiece chessPiece in board.chessPieces) //(IChessPiece chessPiece in pieces)
                        {
                            if (cursor.X == chessPiece.X && cursor.Y == chessPiece.Y)
                            {
                                highlighted = chessPiece;
                                break;
                            }
                        }

                        if (highlighted != null)
                        {
                            if (selection != null)
                            {
                                if (highlighted == selection)
                                {
                                    

                                    selection.Visible = true;

                                    //moves which is a list like renderables
                                    selection = null;
                                    highlighted = null;
                                    possibleMoves.Clear();
                                    //break;
                                }
                                else
                                {
                                    
                                }
                            }
                            else
                            {
                                selection = highlighted;

                                selection.Visible = false;
                                possibleMoves = selection.GetMoves();
                                //moves
                                //renderables = selection.GetMoves();

                                //List<Move> movesListForChessPieces = selection.GetMoves();
                                //foreach (Move move in movesListForChessPieces)
                                //{
                                //    renderables.Add(move);
                                //}

                                //renderer.Render(renderables);
                            }

                        }
                        else
                        {
                            if (selection != null)
                            {

                                foreach (Move move in possibleMoves)
                                {
                                    //renderer.Render(move);

                                    if (move.X == cursor.X && move.Y == cursor.Y)
                                    {
                                        selection.Visible = true;
                                        selection.X = cursor.X;
                                        selection.Y = cursor.Y;
                                        selection = null;
                                        possibleMoves.Clear();
                                        break;
                                    }
                                }

                                
                            }
                            //break;
                        }

                        break; //this is the break to Enter

                }

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


                

                foreach (Move move in possibleMoves)
                {
                    renderer.Render(move);
                }

                foreach (ChessPiece chessPiece in board.chessPieces)
                {
                    renderer.Render(chessPiece);
                }
                
                Console.SetCursorPosition(cursor.X, cursor.Y);
                


            }
        }

        //static public bool IsValidMove(IRenderable piece, Move move)
        //{

        //    List<Move> possibleMoves = piece.GetMoves();
        //    foreach (Move possibleMove in possibleMoves)
        //    {
        //        if (move.X == possibleMove.X && move.Y == possibleMove.Y)
        //        {
        //            return true;
        //        }
        //    }
        //    //never found a valid move
        //    return false;

        //}
    }
}

