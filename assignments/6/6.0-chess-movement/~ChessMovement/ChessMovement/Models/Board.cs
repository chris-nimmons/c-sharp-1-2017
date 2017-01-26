using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class GameBoard
    {
        public State State { get; set; }
        public Piece[] Pieces { get; set; }
        public Move Cursor { get; set; }
        public int TurnCount { get; set; }
        public PieceFactory pieceFactory { get; set; }

        public GameBoard()
        {
            TurnCount = 1;
            Pieces = new Piece[32];
            Cursor = new Move() { X = 15, Y = 10 };
            pieceFactory = new PieceFactory();
        }

        public void Initialize()
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < 32; i++)
            {
                if (i > 15)
                {
                    x = (i + 32) % 8;
                    y = (i + 32) / 8;
                    Pieces[i] = pieceFactory.CreatePiece((PieceID)i, x, y);
                }
                else
                {
                    x = i % 8;
                    y = i / 8;
                    Pieces[i] = pieceFactory.CreatePiece((PieceID)i, x, y);
                }
            }

            State = new State(TurnCount, Pieces);
        }

        #region SetupBoardObs
        //public void SetupBoardObs()
        //{
        //    for (int x = 0; x < 8; x++)
        //    {
        //        for (int y = 0; y < 8; y++)
        //        {
        //            selection.Board[x, y] = new Cell() { X = x, Y = y };
        //        }
        //    }

        //    for (int x = 0; x < 8; x++)
        //    {
        //        selection.Board[x, 1].Piece = new Pawn() { X = x, Y = 1, Color = Color.Black };
        //        selection.Board[x, 6].Piece = new Pawn() { X = x, Y = 6, Color = Color.White };
        //    }

        //    selection.Board[0, 0].Piece = new Rook() { X = 0, Y = 0, Color = Color.Black };
        //    selection.Board[7, 0].Piece = new Rook() { X = 7, Y = 0, Color = Color.Black };
        //    selection.Board[0, 7].Piece = new Rook() { X = 0, Y = 7, Color = Color.White };
        //    selection.Board[7, 7].Piece = new Rook() { X = 7, Y = 7, Color = Color.White };

        //    selection.Board[1, 0].Piece = new Knight() { X = 1, Y = 0, Color = Color.Black };
        //    selection.Board[6, 0].Piece = new Knight() { X = 6, Y = 0, Color = Color.Black };
        //    selection.Board[1, 7].Piece = new Knight() { X = 1, Y = 7, Color = Color.White };
        //    selection.Board[6, 7].Piece = new Knight() { X = 6, Y = 7, Color = Color.White };

        //    selection.Board[2, 0].Piece = new Bishop() { X = 2, Y = 0, Color = Color.Black };
        //    selection.Board[5, 0].Piece = new Bishop() { X = 5, Y = 0, Color = Color.Black };
        //    selection.Board[2, 7].Piece = new Bishop() { X = 2, Y = 7, Color = Color.White };
        //    selection.Board[5, 7].Piece = new Bishop() { X = 5, Y = 7, Color = Color.White };

        //    selection.Board[3, 0].Piece = new Queen() { X = 3, Y = 0, Color = Color.Black };
        //    selection.Board[4, 0].Piece = new King()  { X = 4, Y = 0, Color = Color.Black };
        //    selection.Board[3, 7].Piece = new Queen() { X = 3, Y = 7, Color = Color.White };
        //    selection.Board[4, 7].Piece = new King()  { X = 4, Y = 7, Color = Color.White };

        //    foreach (var topLevelCell in CellArray)
        //    {
        //        if (topLevelCell.Piece != null)
        //        {
        //            topLevelCell.Piece.Board = new Cell[8, 8];

        //            foreach (var cell in CellArray)
        //            {
        //                topLevelCell.Piece.Board[cell.X, cell.Y] = new Cell()
        //                {
        //                    X = cell.X,
        //                    Y = cell.Y,
        //                    Piece = cell.Piece
        //                };
        //            }
        //        }
        //    }
        //}
        #endregion

        public Piece GetSelection(Piece selection, int renderOffsetX, int renderOffsetY)
        {
            var running = true;

            Color currentPlayer;

            if (TurnCount % 2 == 1)
            {
                currentPlayer = Color.White;
            }
            else
            {
                currentPlayer = Color.Black;
            }

            while (running)
            {
                int relativeX = Cursor.X - renderOffsetX;
                int relativeY = Cursor.Y - renderOffsetY;

                Console.SetCursorPosition(Cursor.X, Cursor.Y);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Cursor.Y > 0)
                        {
                            Cursor.Y--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Cursor.Y < Console.BufferHeight)
                        {
                            Cursor.Y++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Cursor.X > 0)
                        {
                            Cursor.X--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Cursor.X < Console.BufferWidth)
                        {
                            Cursor.X++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (relativeX >= 0 && relativeX < 8 &&
                            relativeY >= 0 && relativeY < 8)
                        {
                            if (selection == null)
                            {
                                foreach (var piece in Pieces)
                                {
                                    if (piece.X == relativeX && piece.Y == relativeY && piece.Color == currentPlayer && !piece.Taken)
                                    {
                                        selection = piece;
                                        running = false;
                                        break;
                                    }
                                }
                            }
                            else if (selection != null)
                            {
                                if (selection.X == relativeX && selection.Y == relativeY)
                                {
                                    selection = null;
                                    running = false;
                                }
                                else
                                {
                                    var moves = State.GetMoves(selection);

                                    if (moves.Exists(m => m.X == relativeX && m.Y == relativeY))
                                    {
                                        if (moves.Find(m => m.X == relativeX && m.Y == relativeY).Takeable)
                                        {
                                            var gonerId = State.Board[relativeX, relativeY].PieceId;

                                            Pieces[(int)gonerId].Taken = true;

                                            Pieces[(int)selection.ID].MoveTo(relativeX, relativeY);

                                            selection = null;
                                            TurnCount++;
                                            State = new State(TurnCount, Pieces);
                                            running = false;
                                        }
                                        else
                                        {
                                            Pieces[(int)selection.ID].MoveTo(relativeX, relativeY);

                                            selection = null;
                                            TurnCount++;
                                            State = new State(TurnCount, Pieces);
                                            running = false;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        TurnCount = -1;
                        running = false;
                        break;
                }
            }

            return selection;
        }
    }
}
