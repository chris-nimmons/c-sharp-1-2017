//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ChessMovement
//{
//    public class FutureGenerator
//    {
//        public Piece[] Generate(Piece[] pieces, int depth)
//        {
//            var factory = new PieceFactory();

//            foreach (var piece in pieces)
//            {
//                Console.SetCursorPosition(0, 0);
//                Console.WriteLine("Evaluating piece.ID {0} at a depth of {1}", piece.ID, depth);

//                if (piece.GetMoves().Count > 0)
//                {
//                    var moves = piece.GetMoves();
//                    piece.MoveResults = new Piece[moves.Count][];

//                    for (int r = 0; r < moves.Count; r++)
//                    {
//                        piece.MoveResults[r] = new Piece[32];

//                        for (int p = 0; p < 32; p++)
//                        {
//                            piece.MoveResults[r][p] = factory.CreatePiece(pieces[p].ID, pieces[p].X, pieces[p].Y);
//                        }
//                    }

//                    for (int r = 0; r < moves.Count; r++)
//                    {
//                        for (int p = 0; p < 32; p++)
//                        {
//                            if (moves[r].Takeable)
//                            {
//                                if (piece.MoveResults[r][p].X == moves[r].X && piece.MoveResults[r][p].Y == moves[r].Y)
//                                {
//                                    piece.MoveResults[r][p].Taken = true;
//                                }
//                            }

//                            if (p == (int)piece.ID)
//                            {
//                                piece.MoveResults[r][p].X = moves[r].X;
//                                piece.MoveResults[r][p].Y = moves[r].Y;
//                            }

//                            foreach (var pie in piece.MoveResults[r])
//                            {
//                                if (!pie.Taken)
//                                {
//                                    pie.Board = new Cell[8, 8];

//                                    foreach (var pieP in piece.MoveResults[r])
//                                    {
//                                        if (!pieP.Taken)
//                                        {
//                                            pie.Board[pieP.X, pieP.Y] = new Cell()
//                                            {
//                                                X = pieP.X,
//                                                Y = pieP.Y,
//                                                Piece = factory.CreatePiece(pieP.ID, pieP.X, pieP.Y)
//                                            };
//                                        }
//                                    }
//                                }
//                            }
//                        }

//                        if (depth > 0)
//                        {
//                            var generator = new FutureGenerator();
//                            var future = generator.Generate(piece.MoveResults[r], depth - 1);                           
//                        }
//                    }
//                }
//            }

//            return pieces;
//        }
//    }
//}
