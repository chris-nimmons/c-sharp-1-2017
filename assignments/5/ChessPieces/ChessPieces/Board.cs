using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public Piece Piece { get; set; }
    }

    public class Board
    {
        //public List<Cell> CellsList { get; set; }
        public Cell[,] CellsA { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Color CurrentPlayer { get; set; }
        public int TurnCount { get; set; }
        public Move Cursor { get; set; }

        public Board()
        {
            X = (int)Limit.Left;
            Y = (int)Limit.Upper;
            Size = (int)Limit.Size + 1;
            //CellsList = new List<Cell>();
            CellsA = new Cell[(int)Limit.Size + 1, (int)Limit.Size + 1];
            Cursor = new Move() { X = 15, Y = 10 };
        }

        public void InitBoard()
        {
            TurnCount = 1;

            for (int height = 0; height < Size; height++)
            {
                for (int width = 0; width < Size; width++)
                {
                    if (width % 2 == 0)
                    {
                        if (height % 2 == 0)
                        {
                            CellsA[width, height] = new Cell() { X = X + width, Y = Y + height, Color = ConsoleColor.Gray };
                            //CellsList.Add(new Cell() { X = width, Y = height, Color = ConsoleColor.Gray });
                        }
                        else
                        {
                            CellsA[width, height] = new Cell() { X = X + width, Y = Y + height, Color = ConsoleColor.DarkGray };
                            //CellsList.Add(new Cell() { X = width, Y = height, Color = ConsoleColor.DarkGray });
                        }
                    }
                    else
                    {
                        if (height % 2 != 0)
                        {
                            CellsA[width, height] = new Cell() { X = X + width, Y = Y + height, Color = ConsoleColor.Gray };
                            //CellsList.Add(new Cell() { X = width, Y = height, Color = ConsoleColor.Gray });
                        }
                        else
                        {
                            CellsA[width, height] = new Cell() { X = X + width, Y = Y + height, Color = ConsoleColor.DarkGray };
                            //CellsList.Add(new Cell() { X = width, Y = height, Color = ConsoleColor.DarkGray });
                        }
                    }
                }
            }

            for (int width = 0; width < Size; width++)
            {
                CellsA[width, 1].Piece = new Pawn() { X = width + X, Y = Y + 1, Color = Color.Black, ID = (PieceID)width };
                CellsA[width, 6].Piece = new Pawn() { X = width + X, Y = Y + 6, Color = Color.White, ID = (PieceID)width };
            }

            CellsA[0, 0].Piece = new Rook() { X = X, Y = Y, Color = Color.Black, ID = PieceID.R1 };
            CellsA[7, 0].Piece = new Rook() { X = X + 7, Y = Y, Color = Color.Black, ID = PieceID.R2 };
            CellsA[0, 7].Piece = new Rook() { X = X, Y = Y + 7, Color = Color.White, ID = PieceID.R1 };
            CellsA[7, 7].Piece = new Rook() { X = X + 7, Y = Y + 7, Color = Color.White, ID = PieceID.R2 };

            CellsA[1, 0].Piece = new Knight() { X = X + 1, Y = Y, Color = Color.Black, ID = PieceID.H1 };
            CellsA[6, 0].Piece = new Knight() { X = X + 6, Y = Y, Color = Color.Black, ID = PieceID.H2 };
            CellsA[1, 7].Piece = new Knight() { X = X + 1, Y = Y + 7, Color = Color.White, ID = PieceID.H1 };
            CellsA[6, 7].Piece = new Knight() { X = X + 6, Y = Y + 7, Color = Color.White, ID = PieceID.H2 };

            CellsA[2, 0].Piece = new Bishop() { X = X + 2, Y = Y, Color = Color.Black, ID = PieceID.B1 };
            CellsA[5, 0].Piece = new Bishop() { X = X + 5, Y = Y, Color = Color.Black, ID = PieceID.B2 };
            CellsA[2, 7].Piece = new Bishop() { X = X + 2, Y = Y + 7, Color = Color.White, ID = PieceID.B1 };
            CellsA[5, 7].Piece = new Bishop() { X = X + 5, Y = Y + 7, Color = Color.White, ID = PieceID.B2 };

            CellsA[3, 0].Piece = new Queen() { X = X + 3, Y = Y, Color = Color.Black, ID = PieceID.Q };
            CellsA[4, 0].Piece = new King() { X = X + 4, Y = Y, Color = Color.Black, ID = PieceID.K };
            CellsA[3, 7].Piece = new Queen() { X = X + 3, Y = Y + 7, Color = Color.White, ID = PieceID.Q };
            CellsA[4, 7].Piece = new King() { X = X + 4, Y = Y + 7, Color = Color.White, ID = PieceID.K };

            foreach (var cell in CellsA)
            {
                if (cell.Piece != null)
                {
                    cell.Piece.PresentBoard = new Cell[8, 8];

                    foreach (var currentCell in CellsA)
                    {
                        cell.Piece.PresentBoard[currentCell.X, currentCell.Y] = new Cell()
                        {
                            X = currentCell.X,
                            Y = currentCell.Y,
                            Piece = currentCell.Piece
                        };
                    }
                }
            }

            #region Old list stuff
            //for (int w = X; w < X + Size; w++)
            //{
            //    CellsList.FindAll(c => c.Y == Y + 1).ForEach(cell =>
            //        {
            //            cell.Piece = new Pawn() { X = w, Y = Y + 6, Color = Color.Black };
            //        });

            //    CellsList.FindAll(c => c.Y == Y + 6).ForEach(cell =>
            //        {
            //            cell.Piece = new Pawn() { X = w, Y = Y + 6, Color = Color.White };
            //        });
            //}

            //CellsList.FindAll(c => (c.Y == Y) && (c.X == X || c.X == (int)Limit.Right)).ForEach(cell =>
            //    {
            //        cell.Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.Black };
            //    });

            //CellsList.FindAll(c => (c.Y == (int)Limit.Lower) && (c.X == X || c.X == (int)Limit.Right)).ForEach(cell =>
            //    {
            //        cell.Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.White };
            //    });

            //CellsList.FindAll(c => (c.Y == Y) && (c.X == X + 1 || c.X == (int)Limit.Right - 1)).ForEach(cell =>
            //    {
            //        cell.Piece = new Knight() { X = cell.X, Y = cell.Y, Color = Color.Black };
            //    });

            //CellsList.FindAll(c => (c.Y == (int)Limit.Lower) && (c.X == X + 1 || c.X == (int)Limit.Right - 1)).ForEach(cell =>
            //    {
            //        cell.Piece = new Knight() { X = cell.X, Y = cell.Y, Color = Color.White };
            //    });

            //CellsList.FindAll(c => (c.Y == Y) && (c.X == X + 2 || c.X == (int)Limit.Right - 2)).ForEach(cell =>
            //{
            //    cell.Piece = new Bishop() { X = cell.X, Y = cell.Y, Color = Color.Black };
            //});

            //CellsList.FindAll(c => (c.Y == (int)Limit.Lower) && (c.X == X + 2 || c.X == (int)Limit.Right - 2)).ForEach(cell =>
            //{
            //    cell.Piece = new Bishop() { X = cell.X, Y = cell.Y, Color = Color.White };
            //});

            //CellsList.Find(c => (c.Y == Y) && (c.X == X + 3)).Piece = new Queen() { X = X + 3, Y = Y, Color = Color.Black };
            //CellsList.Find(c => (c.Y == Y) && (c.X == X + 4)).Piece = new King() { X = X + 4, Y = Y, Color = Color.Black };

            //CellsList.Find(c => (c.Y == (int)Limit.Lower) && (c.X == X + 3)).Piece = new Queen() { X = X + 3, Y = Y, Color = Color.White };
            //CellsList.Find(c => (c.Y == (int)Limit.Lower) && (c.X == X + 4)).Piece = new King() { X = X + 4, Y = Y, Color = Color.White };
            #endregion
        }

        public List<Move> FilterMoves(Cell cell)
        {
            List<Move> proposedMoves = new List<Move>();

            #region Old switch with lots of old bad confusing ridiculous code
            //switch (cell.Piece.Type)
            //{
            //    case Type.Pawn: // Pawns can move one space towards the other side of the board unless they have never been moved, then they can move two spaces towards the other side of the board
            //        #region Pawn
            //        if (cell.Piece.Color == Color.White) // White pawns can only move up the board
            //        {
            //            if (cell.Piece.Y == (int)Limit.Upper) // Check if the white pawn reached the other side of the board
            //            {
            //                CellsA[cell.Piece.X, cell.Piece.Y].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.White }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
            //            }

            //            if (cell.Piece.TimesMoved == 0) // Pawns can move two spaces on their first move
            //            {
            //                if (CellsA[cell.Piece.X, cell.Piece.Y - 2].Piece == null) // As long as there isn't a piece two spaces ahead
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 2 }); // Add the move
            //                }
            //            }

            //            if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece == null) // As long as there isn't a piece one space ahead
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1 }); // Add the move
            //            }

            //            if (cell.Piece.X < 7)
            //            {
            //                if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece != null &&
            //                    CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece.Color == Color.Black)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1, Takeable = true });
            //                }
            //            }

            //            if (cell.Piece.X > 0)
            //            {
            //                if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece != null &&
            //                    CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece.Color == Color.Black)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1, Takeable = true });
            //                }
            //            }
            //        }
            //        if (cell.Piece.Color == Color.Black) // Black pawns can only move down the board
            //        {
            //            if (cell.Piece.Y == (int)Limit.Lower) // Check if the black pawn reached the other side of the board
            //            {
            //                CellsA[cell.Piece.X, cell.Piece.Y].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.Black }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
            //            }
            //            else if (cell.Piece.TimesMoved == 0) // Pawns can move two spaces on their first move
            //            {
            //                if (CellsA[cell.Piece.X, cell.Piece.Y + 2].Piece == null) // As long as there isn't a piece two spaces ahead
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 2 }); // Add the move
            //                }
            //            }

            //            if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece == null) // As long as there isn't a piece one space ahead
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1 }); // Add the move
            //            }

            //            if (cell.Piece.X < 7)
            //            {
            //                if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece != null &&
            //                    CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece.Color == Color.White)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1, Takeable = true });
            //                }
            //            }

            //            if (cell.Piece.X > 0)
            //            {
            //                if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece != null &&
            //                    CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece.Color == Color.White)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1, Takeable = true });
            //                }
            //            }

            //        }
            //        return proposedMoves;
            //    #endregion Pawn
            //    case Type.Rook: // Rooks can move as many spaces in any horizontal or vertical direction as are empty in each direction
            //        #region Rook
            //        for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++) // Iterate right
            //        {
            //            #region Iterate right
            //            if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int width = 1; width <= cell.Piece.X; width++) // Iterate left
            //        {
            //            #region Iterate left
            //            if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int height = 1; height < cell.Piece.Y; height++) // Iterate up
            //        {
            //            #region Iterate up
            //            if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++) // Iterate down
            //        {
            //            #region Iterate down
            //            if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        return proposedMoves;
            //    #endregion Rook
            //    case Type.King: // Kings can move into any of the eight surrounding spaces, taking any piece of an opposite color in those spaces
            //        #region King
            //        if (cell.Piece.Y > 0)
            //        {
            //            if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece == null) // Check space above is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1 });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color) // If not empty, if the piece of an opposite color
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.Y < 7)
            //        {
            //            if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece == null) // Check space below is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1 });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X > 0)
            //        {
            //            if (CellsA[cell.Piece.X - 1, cell.Piece.Y].Piece == null) // Check space to left is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X - 1, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X < 7)
            //        {
            //            if (CellsA[cell.Piece.X + 1, cell.Piece.Y].Piece == null) // Check space to right is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X + 1, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X > 0 && cell.Piece.Y > 0)
            //        {
            //            if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece == null) // Check up left is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1 });
            //            }
            //            else if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X > 0 && cell.Piece.Y < 7)
            //        {
            //            if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece == null) // Check down left is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1 });
            //            }
            //            else if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X < 7 && cell.Piece.Y > 0)
            //        {
            //            if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece == null) // Check up right is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1 });
            //            }
            //            else if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1, Takeable = true });
            //            }
            //        }

            //        if (cell.Piece.X < 7 && cell.Piece.Y < 7)
            //        {
            //            if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece == null) // Check down right is empty
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1 });
            //            }
            //            else if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1, Takeable = true });
            //            }
            //        }
            //        return proposedMoves;
            //    #endregion King
            //    case Type.Queen: // Queens can move as many spaces in any direction as are empty in that direction
            //        #region Queen
            //        for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++) // Iterate right
            //        {
            //            #region Iterate right
            //            if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int width = 1; width <= cell.Piece.X; width++) // Iterate left
            //        {
            //            #region Iterate left
            //            if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y });
            //            }
            //            else if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++) // Iterate down
            //        {
            //            #region Iterate down
            //            if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }
            //        for (int height = 1; height < cell.Piece.Y; height++) // Iterate up
            //        {
            //            #region Iterate up
            //            if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece == null)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height });
            //            }
            //            else if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //            {
            //                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height, Takeable = true });
            //                break;
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            #endregion
            //        }

            //        #region Diagonal Up Left
            //        if (cell.Piece.Y < (int)Limit.Size / 2) // Is it closest to the top or bottom
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Is it closest to the left or right
            //            {
            //                if (cell.Piece.X < cell.Piece.Y) // Is it closer to the left than the top
            //                {
            //                    for (int width = 1; width <= cell.Piece.X; width++) // Iterate to the top of the board
            //                    {
            //                        if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null) // Check cell is empty
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
            //                        }
            //                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color) // Is the piece of opposite color
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else // Closer to top than the left
            //                {
            //                    for (int height = 1; height <= cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                        }
            //                        else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else // It is closer to top than the left
            //            {
            //                for (int height = 1; height <= cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Is it closest to the left
            //            {
            //                for (int width = 1; width <= cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
            //                    }
            //                    else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else // Closer to top than left
            //            {
            //                for (int height = 1; height <= cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Up Right
            //        if (cell.Piece.Y < (int)Limit.Size / 2) // Closer to top
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2) // Closer to right
            //            {
            //                if (cell.Piece.X > (int)Limit.Size - cell.Piece.Y) // Closer to right than top
            //                {
            //                    for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
            //                        }
            //                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height < cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                        }
            //                        else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if ((int)Limit.Size - cell.Piece.X < cell.Piece.Y)
            //            {
            //                for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
            //                    }
            //                    else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Down Left
            //        if (cell.Piece.Y > (int)Limit.Size / 2) // Closer to bottom
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Closer to left
            //            {
            //                if (cell.Piece.X < (int)Limit.Size - cell.Piece.Y) // Closer to the left than bottom
            //                {
            //                    for (int width = 1; width <= cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
            //                        }
            //                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                        }
            //                        else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else // Closer to top
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Closer to left
            //            {
            //                for (int width = 1; width <= cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
            //                    }
            //                    else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Down Right
            //        if (cell.Piece.Y > (int)Limit.Size / 2) // Closer to bottom
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2) // Closer to right
            //            {
            //                if (cell.Piece.X > cell.Piece.Y) // Closer to right than bottom
            //                {
            //                    for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
            //                        }
            //                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                        }
            //                        else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }

            //            }
            //        }
            //        else
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2)
            //            {
            //                for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
            //                    }
            //                    else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }

            //            }
            //            else
            //            {
            //                for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion
            //        return proposedMoves;
            //    #endregion
            //    case Type.Bishop: // Bishops can move as many spaces in any diagonal direction as are empty in that direction
            //        #region Bishop
            //        #region Diagonal Up Left
            //        if (cell.Piece.Y < (int)Limit.Size / 2) // Is it closest to the top or bottom
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Is it closest to the left or right
            //            {
            //                if (cell.Piece.X < cell.Piece.Y) // Is it closer to the left than the top
            //                {
            //                    for (int width = 1; width <= cell.Piece.X; width++) // Iterate to the top of the board
            //                    {
            //                        if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null) // Check cell is empty
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
            //                        }
            //                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color) // Is the piece of opposite color
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else // Closer to top than the left
            //                {
            //                    for (int height = 1; height <= cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                        }
            //                        else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else // It is closer to top than the left
            //            {
            //                for (int height = 1; height <= cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Is it closest to the left
            //            {
            //                for (int width = 1; width <= cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
            //                    }
            //                    else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else // Closer to top than left
            //            {
            //                for (int height = 1; height <= cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Up Right
            //        if (cell.Piece.Y < (int)Limit.Size / 2) // Closer to top
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2) // Closer to right
            //            {
            //                if (cell.Piece.X > (int)Limit.Size - cell.Piece.Y) // Closer to right than top
            //                {
            //                    for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
            //                        }
            //                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height < cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                        }
            //                        else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2)
            //            {
            //                for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
            //                    }
            //                    else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Down Left
            //        if (cell.Piece.Y > (int)Limit.Size / 2) // Closer to bottom
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Closer to left
            //            {
            //                if (cell.Piece.X < (int)Limit.Size - cell.Piece.Y) // Closer to the left than bottom
            //                {
            //                    for (int width = 1; width <= cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
            //                        }
            //                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                        }
            //                        else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        else // Closer to top
            //        {
            //            if (cell.Piece.X < (int)Limit.Size / 2) // Closer to left
            //            {
            //                for (int width = 1; width <= cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
            //                    }
            //                    else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Diagonal Down Right
            //        if (cell.Piece.Y > (int)Limit.Size / 2) // Closer to bottom
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2) // Closer to right
            //            {
            //                if (cell.Piece.X > cell.Piece.Y) // Closer to right than bottom
            //                {
            //                    for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                    {
            //                        if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
            //                        }
            //                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                    {
            //                        if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                        }
            //                        else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                        {
            //                            proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }

            //            }
            //        }
            //        else
            //        {
            //            if (cell.Piece.X > (int)Limit.Size / 2)
            //            {
            //                for (int width = 1; width < (int)Limit.Size - cell.Piece.X; width++)
            //                {
            //                    if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
            //                    }
            //                    else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }

            //            }
            //            else
            //            {
            //                for (int height = 1; height < (int)Limit.Size - cell.Piece.Y; height++)
            //                {
            //                    if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
            //                    }
            //                    else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
            //                    {
            //                        proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        #endregion
            //        return proposedMoves;
            //    #endregion
            //    case Type.Knight:
            //        #region Knight
            //        for (int i = 1; i <= 2; i++)
            //        {
            //            if (cell.Piece.X + i - 3 > -1 && cell.Piece.X + i - 3 <= (int)Limit.Size &&
            //                cell.Piece.Y + i > -1 && cell.Piece.Y + i <= (int)Limit.Size)
            //            {
            //                if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i].Piece == null)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i });
            //                }
            //                else if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i].Piece.Color != cell.Piece.Color)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i, Takeable = true });
            //                }
            //            }


            //            if (cell.Piece.X + i - 3 > -1 && cell.Piece.X + i - 3 <= (int)Limit.Size &&
            //                cell.Piece.Y + i * -1 > -1 && cell.Piece.Y + i * -1 <= (int)Limit.Size)
            //            {
            //                if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i * -1].Piece == null)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i * -1 });
            //                }
            //                else if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i * -1].Piece.Color != cell.Piece.Color)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i * -1, Takeable = true });
            //                }
            //            }

            //            if (cell.Piece.X + i > -1 && cell.Piece.X + i <= (int)Limit.Size &&
            //                cell.Piece.Y + i - 3 > -1 && cell.Piece.Y + i - 3 <= (int)Limit.Size)
            //            {
            //                if (CellsA[cell.Piece.X + i, cell.Piece.Y + i - 3].Piece == null)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + i - 3 });
            //                }
            //                else if (CellsA[cell.Piece.X + i, cell.Piece.Y + i - 3].Piece.Color != cell.Piece.Color)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + i - 3, Takeable = true });
            //                }
            //            }

            //            if (cell.Piece.X + i > -1 && cell.Piece.X + i <= (int)Limit.Size &&
            //                cell.Piece.Y + (i - 3) * -1 > -1 && cell.Piece.Y + (i - 3) * -1 <= (int)Limit.Size)
            //            {
            //                if (CellsA[cell.Piece.X + i, cell.Piece.Y + (i - 3) * -1].Piece == null)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + (i - 3) * -1 });
            //                }
            //                else if (CellsA[cell.Piece.X + i, cell.Piece.Y + (i - 3) * -1].Piece.Color != cell.Piece.Color)
            //                {
            //                    proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + (i - 3) * -1, Takeable = true });
            //                }
            //            }
            //        }
            //        return proposedMoves;
            //        #endregion
            //}
            #endregion

            switch (cell.Piece.Type)
            {
                case Type.Pawn:
                    #region Pawn
                    if (cell.Piece.Color == Color.White) // White pawns can only move up the board
                    {
                        if (cell.Piece.Y == (int)Limit.Upper) // Check if the white pawn reached the other side of the board
                        {
                            CellsA[cell.Piece.X, cell.Piece.Y].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.White }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                            break;
                        }

                        if (cell.Piece.Y == 6) // Pawns can move two spaces on their first move
                        {
                            if (CellsA[cell.Piece.X, cell.Piece.Y - 2].Piece == null) // As long as there isn't a piece two spaces ahead
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 2 }); // Add the move
                            }
                        }

                        if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece == null) // As long as there isn't a piece one space ahead
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1 }); // Add the move
                        }

                        if (cell.Piece.X < 7)
                        {
                            if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece != null &&
                                CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece.Color == Color.Black)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1, Takeable = true });
                            }
                        }

                        if (cell.Piece.X > 0)
                        {
                            if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece != null &&
                                CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece.Color == Color.Black)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1, Takeable = true });
                            }
                        }
                    }
                    if (cell.Piece.Color == Color.Black) // Black pawns can only move down the board
                    {
                        if (cell.Piece.Y == (int)Limit.Lower) // Check if the black pawn reached the other side of the board
                        {
                            CellsA[cell.Piece.X, cell.Piece.Y].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.Black }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                            break;
                        }
                        else if (cell.Piece.Y == 1) // Pawns can move two spaces on their first move
                        {
                            if (CellsA[cell.Piece.X, cell.Piece.Y + 2].Piece == null) // As long as there isn't a piece two spaces ahead
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 2 }); // Add the move
                            }
                        }

                        if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece == null) // As long as there isn't a piece one space ahead
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1 }); // Add the move
                        }

                        if (cell.Piece.X < 7)
                        {
                            if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece != null &&
                                CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece.Color == Color.White)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1, Takeable = true });
                            }
                        }

                        if (cell.Piece.X > 0)
                        {
                            if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece != null &&
                                CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece.Color == Color.White)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1, Takeable = true });
                            }
                        }

                    }
                    return proposedMoves;
                #endregion Pawn
                case Type.Rook:
                    #region Rook
                #region Upward iteration
                    for (int height = 1; height <= cell.Piece.Y; height++)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                #endregion
                #region Downward iteration
                    for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                #endregion
                #region Leftward iteration
                    for (int width = 1; width <= cell.Piece.X; width++)
                    {
                        if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = cell.Piece.X - width, Y = cell.Piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                #endregion
                #region Rightward iteration
                    for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                    {
                        if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = cell.Piece.X + width, Y = cell.Piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    return proposedMoves;
                    #endregion
                case Type.King:
                    #region King
                    if (cell.Piece.Y > 0)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece == null) // Check space above is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1 });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color) // If not empty, if the piece of an opposite color
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 1, Takeable = true });
                        }
                    }

                    if (cell.Piece.Y < 7)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece == null) // Check space below is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1 });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 1, Takeable = true });
                        }
                    }

                    if (cell.Piece.X > 0)
                    {
                        if (CellsA[cell.Piece.X - 1, cell.Piece.Y].Piece == null) // Check space to left is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X - 1, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y, Takeable = true });
                        }
                    }

                    if (cell.Piece.X < 7)
                    {
                        if (CellsA[cell.Piece.X + 1, cell.Piece.Y].Piece == null) // Check space to right is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X + 1, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y, Takeable = true });
                        }
                    }

                    if (cell.Piece.X > 0 && cell.Piece.Y > 0)
                    {
                        if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece == null) // Check up left is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1 });
                        }
                        else if (CellsA[cell.Piece.X - 1, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y - 1, Takeable = true });
                        }
                    }

                    if (cell.Piece.X > 0 && cell.Piece.Y < 7)
                    {
                        if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece == null) // Check down left is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1 });
                        }
                        else if (CellsA[cell.Piece.X - 1, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - 1, Y = cell.Piece.Y + 1, Takeable = true });
                        }
                    }

                    if (cell.Piece.X < 7 && cell.Piece.Y > 0)
                    {
                        if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece == null) // Check up right is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1 });
                        }
                        else if (CellsA[cell.Piece.X + 1, cell.Piece.Y - 1].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y - 1, Takeable = true });
                        }
                    }

                    if (cell.Piece.X < 7 && cell.Piece.Y < 7)
                    {
                        if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece == null) // Check down right is empty
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1 });
                        }
                        else if (CellsA[cell.Piece.X + 1, cell.Piece.Y + 1].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + 1, Y = cell.Piece.Y + 1, Takeable = true });
                        }
                    }
                    return proposedMoves;
                #endregion King
                case Type.Queen:
                    #region Queen
                    #region Upward iteration
                    for (int height = 1; height <= cell.Piece.Y; height++)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Downward iteration
                    for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                    {
                        if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
                        }
                        else if (CellsA[cell.Piece.X, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Leftward iteration
                    for (int width = 1; width <= cell.Piece.X; width++)
                    {
                        if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X - width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = cell.Piece.X - width, Y = cell.Piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Rightward iteration
                    for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                    {
                        if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
                        }
                        else if (CellsA[cell.Piece.X + width, cell.Piece.Y].Piece.Color != cell.Piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = cell.Piece.X + width, Y = cell.Piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                #endregion
                    #region Up left iteration
                    if (cell.Piece.X <= cell.Piece.Y)
                    {
                        for (int width = 1; width <= cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
                            }
                            else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
                            }
                            else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                #endregion
                    #region Up right iteration
                    if (cell.Piece.X <= (int)Limit.Size - cell.Piece.Y)
                    {
                        for (int height = 1; height <= cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
                            }
                            else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
                            }
                            else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                #endregion
                    #region Down right iteration
                    if (cell.Piece.X >= cell.Piece.Y)
                    {
                        for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
                            }
                            else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
                            }
                            else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                #endregion
                    #region Down left iteration
                    if (cell.Piece.X <= (int)Limit.Size - cell.Piece.Y)
                    {
                        for (int width = 1; width <= cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
                            }
                            else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
                            }
                            else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    return proposedMoves;
                    #endregion
                case Type.Bishop:
                    #region Bishop
                    #region Up left iteration
                    if (cell.Piece.X <= cell.Piece.Y)
                    {
                        for (int width = 1; width <= cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width });
                            }
                            else if (CellsA[cell.Piece.X - width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y - width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height });
                            }
                            else if (CellsA[cell.Piece.X - height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y - height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    #region Up right iteration
                    if (cell.Piece.X <= (int)Limit.Size - cell.Piece.Y)
                    {
                        for (int height = 1; height <= cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height });
                            }
                            else if (CellsA[cell.Piece.X + height, cell.Piece.Y - height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y - height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width });
                            }
                            else if (CellsA[cell.Piece.X + width, cell.Piece.Y - width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y - width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    #region Down right iteration
                    if (cell.Piece.X >= cell.Piece.Y)
                    {
                        for (int width = 1; width <= (int)Limit.Size - cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width });
                            }
                            else if (CellsA[cell.Piece.X + width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y + width, Takeable = true });
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height });
                            }
                            else if (CellsA[cell.Piece.X + height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + height, Y = cell.Piece.Y + height, Takeable = true });
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    #region Down left iteration
                    if (cell.Piece.X <= (int)Limit.Size - cell.Piece.Y)
                    {
                        for (int width = 1; width <= cell.Piece.X; width++)
                        {
                            if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width });
                            }
                            else if (CellsA[cell.Piece.X - width, cell.Piece.Y + width].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - width, Y = cell.Piece.Y + width, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= (int)Limit.Size - cell.Piece.Y; height++)
                        {
                            if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height });
                            }
                            else if (CellsA[cell.Piece.X - height, cell.Piece.Y + height].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X - height, Y = cell.Piece.Y + height, Takeable = true });
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    return proposedMoves;
                    #endregion
                case Type.Knight:
                    #region Knight
                    for (int i = 1; i <= 2; i++)
                    {
                        if (cell.Piece.X + i - 3 > -1 && cell.Piece.X + i - 3 <= (int)Limit.Size &&
                            cell.Piece.Y + i > -1 && cell.Piece.Y + i <= (int)Limit.Size)
                        {
                            if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i });
                            }
                            else if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i, Takeable = true });
                            }
                        }


                        if (cell.Piece.X + i - 3 > -1 && cell.Piece.X + i - 3 <= (int)Limit.Size &&
                            cell.Piece.Y + i * -1 > -1 && cell.Piece.Y + i * -1 <= (int)Limit.Size)
                        {
                            if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i * -1].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i * -1 });
                            }
                            else if (CellsA[cell.Piece.X + i - 3, cell.Piece.Y + i * -1].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i - 3, Y = cell.Piece.Y + i * -1, Takeable = true });
                            }
                        }

                        if (cell.Piece.X + i > -1 && cell.Piece.X + i <= (int)Limit.Size &&
                            cell.Piece.Y + i - 3 > -1 && cell.Piece.Y + i - 3 <= (int)Limit.Size)
                        {
                            if (CellsA[cell.Piece.X + i, cell.Piece.Y + i - 3].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + i - 3 });
                            }
                            else if (CellsA[cell.Piece.X + i, cell.Piece.Y + i - 3].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + i - 3, Takeable = true });
                            }
                        }

                        if (cell.Piece.X + i > -1 && cell.Piece.X + i <= (int)Limit.Size &&
                            cell.Piece.Y + (i - 3) * -1 > -1 && cell.Piece.Y + (i - 3) * -1 <= (int)Limit.Size)
                        {
                            if (CellsA[cell.Piece.X + i, cell.Piece.Y + (i - 3) * -1].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + (i - 3) * -1 });
                            }
                            else if (CellsA[cell.Piece.X + i, cell.Piece.Y + (i - 3) * -1].Piece.Color != cell.Piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = cell.Piece.X + i, Y = cell.Piece.Y + (i - 3) * -1, Takeable = true });
                            }
                        }
                    }
                    return proposedMoves;
                    #endregion
            }

            return proposedMoves;
        }

        public Piece SelectionLoop(Piece selection)
        {
            var running = true;

            if (TurnCount % 2 == 0)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }

            while (running)
            {
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
                        if (Cursor.X >= 10 && Cursor.X < 18 &&
                            Cursor.Y >= 5 && Cursor.Y < 13)
                        {
                            if (selection == null)
                            {
                                if (CellsA[Cursor.X - 10, Cursor.Y - 5].Piece != null && CellsA[Cursor.X - 10, Cursor.Y - 5].Piece.Color == CurrentPlayer)
                                {
                                    selection = CellsA[Cursor.X - 10, Cursor.Y - 5].Piece;
                                    running = false;
                                }
                            }
                            else if (selection != null)
                            {
                                if (selection.X == Cursor.X - 10 && selection.Y == Cursor.Y - 5)
                                {
                                    selection = null;
                                    running = false;
                                }
                                else 
                                {
                                    var moves = FilterMoves(CellsA[selection.X, selection.Y]);
                                    if (moves.Exists(m => m.X == Cursor.X - 10 && m.Y == Cursor.Y - 5))
                                    {
                                        if (moves.Find(m => m.X == Cursor.X - 10 && m.Y == Cursor.Y - 5).Takeable)
                                        {
                                            CellsA[Cursor.X - 10, Cursor.Y - 5].Piece = new Piece() { X = Cursor.X - 10, Y = Cursor.Y - 5, TimesMoved = selection.TimesMoved++, Type = selection.Type, Color = selection.Color };
                                            CellsA[selection.X, selection.Y].Piece = null;
                                            selection = null;
                                            TurnCount++;
                                            running = false;
                                        }
                                        else
                                        {
                                            CellsA[Cursor.X - 10, Cursor.Y - 5].Piece = new Piece() { X = Cursor.X - 10, Y = Cursor.Y - 5, TimesMoved = selection.TimesMoved++, Type = selection.Type, Color = selection.Color };
                                            CellsA[selection.X, selection.Y].Piece = null;
                                            selection = null;
                                            TurnCount++;
                                            running = false;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }

            return selection;
        }
    }
}
