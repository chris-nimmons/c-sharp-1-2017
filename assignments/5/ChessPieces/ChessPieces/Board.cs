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
        public IPiece Piece { get; set; }
    }

    public class Board
    {
        //public List<Cell> CellsList { get; set; }
        public Cell[,] CellsA { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }

        public Board()
        {
            X = (int)Limit.Left;
            Y = (int)Limit.Upper;
            Size = (int)Limit.Size;
            //CellsList = new List<Cell>();
            CellsA = new Cell[(int)Limit.Size, (int)Limit.Size];
        }

        public void InitBoard()
        {
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
                CellsA[width, 1].Piece = new Pawn() { X = width + X, Y = Y + 1, Color = Color.Black };
                CellsA[width, 6].Piece = new Pawn() { X = width + X, Y = Y + 6, Color = Color.White };
            }

            CellsA[0, 0].Piece = new Rook() { X = X, Y = Y, Color = Color.Black };
            CellsA[7, 0].Piece = new Rook() { X = X + 7, Y = Y, Color = Color.Black };
            CellsA[0, 7].Piece = new Rook() { X = X, Y = Y + 7, Color = Color.White };
            CellsA[7, 7].Piece = new Rook() { X = X + 7, Y = Y + 7, Color = Color.White };

            CellsA[1, 0].Piece = new Knight() { X = X + 1, Y = Y, Color = Color.Black };
            CellsA[6, 0].Piece = new Knight() { X = X + 6, Y = Y, Color = Color.Black };
            CellsA[1, 7].Piece = new Knight() { X = X + 1, Y = Y + 7, Color = Color.White };
            CellsA[6, 7].Piece = new Knight() { X = X + 6, Y = Y + 7, Color = Color.White };

            CellsA[2, 0].Piece = new Bishop() { X = X + 2, Y = Y, Color = Color.Black };
            CellsA[5, 0].Piece = new Bishop() { X = X + 5, Y = Y, Color = Color.Black };
            CellsA[2, 7].Piece = new Bishop() { X = X + 2, Y = Y + 7, Color = Color.White };
            CellsA[5, 7].Piece = new Bishop() { X = X + 5, Y = Y + 7, Color = Color.White };

            CellsA[3, 0].Piece = new Queen() { X = X + 3, Y = Y, Color = Color.Black };
            CellsA[4, 0].Piece = new King() { X = X + 4, Y = Y, Color = Color.Black };
            CellsA[3, 7].Piece = new Queen() { X = X + 3, Y = Y + 7, Color = Color.White };
            CellsA[4, 7].Piece = new King() { X = X + 4, Y = Y + 7, Color = Color.White };

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
        }

        //public List<Move> FilterMoves(Cell cell)
        //{
        //    List<Move> proposedMoves = cell.Piece.GetMoves();

        //    switch (cell.Piece.Type)
        //    {
        //        case Type.Pawn:
        //            if (cell.Piece.Color == Color.White)
        //            {
        //                if (cell.Piece.Y == (int)Limit.Upper)
        //                {
        //                    CellsA[cell.Piece.Xi, cell.Piece.Yi].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.White };
        //                }
        //                else if (cell.Piece.TimesMoved == 0)
        //                {
        //                    if (CellsA[cell.Piece.Xi, cell.Piece.Yi - 2].Piece == null)
        //                    {
        //                        proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y - 2 });
        //                    }
        //                }

        //                if (CellsA[cell.Piece.Xi, cell.Piece.Yi - 1].Piece == null)
        //                {
        //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Yi - 1 });
        //                }
        //            }
        //            if (cell.Piece.Color == Color.Black)
        //            {
        //                if (cell.Piece.Y == (int)Limit.Lower)
        //                {
        //                    CellsA[cell.Piece.Xi, cell.Piece.Yi].Piece = new Rook() { X = cell.X, Y = cell.Y, Color = Color.Black };
        //                }
        //                else if (cell.Piece.TimesMoved == 0)
        //                {
        //                    if (CellsA[cell.Piece.Xi, cell.Piece.Yi + 2].Piece == null)
        //                    {
        //                        proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + 2 });
        //                    }
        //                }

        //                if (CellsA[cell.Piece.Xi, cell.Piece.Yi + 2].Piece == null)
        //                {
        //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Yi + 1 });
        //                }
        //            }
        //            return proposedMoves;
        //        case Type.Rook:
        //            for (int width = 0; width > 0 - cell.Piece.Xi; width--)
        //            {
        //                if (CellsA[width, cell.Piece.Yi].Piece != null)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    proposedMoves.Add(new Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
        //                }
        //            }
        //            for (int width = 0; width < (int)Limit.Right - cell.Piece.X; width++)
        //            {
        //                if (CellsA[width, cell.Piece.Yi].Piece != null)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    proposedMoves.Add(new ChessPieces.Move() { X = cell.Piece.X + width, Y = cell.Piece.Y });
        //                }
        //            }
        //            for (int height = 0; height > 0 - cell.Piece.Yi; height++)
        //            {
        //                if (CellsA[cell.Piece.Xi, height].Piece != null)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
        //                }
        //            }
        //            for (int height = 0; height < (int)Limit.Lower - cell.Piece.Y; height++)
        //            {
        //                if (CellsA[cell.Piece.Xi, height].Piece != null)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    proposedMoves.Add(new Move() { X = cell.Piece.X, Y = cell.Piece.Y + height });
        //                }
        //            }
        //            return proposedMoves;
        //        case Type.King:
        //        case Type.Queen:
        //        case Type.Bishop:
        //        case Type.Knight:
        //            break;

        //    }

        //    //if (cell.Piece.Color == Color.Black)
        //    //{
        //    //    if (Cells.Find(c => (c.X == cell.Piece.X) && (c.Y == cell.Piece.Y)).Piece != null)
        //    //        switch (cell.Piece.Type)
        //    //        {
        //    //            case Type.Pawn:
        //    //                if (cell.Piece.TimesMoved > 0)
        //    //                {
        //    //                    foreach (var c in Cells)
        //    //                    {
        //    //                        if (c.Piece != null)
        //    //                        {
        //    //                            proposedMoves.RemoveAll(move => (move.X == c.X) && (move.Y == c.Y));
        //    //                        }
        //    //                    }
        //    //                }
        //    //                proposedMoves.RemoveAll(m => Cells.FindAll(c => ))
        //    //                foreach (Move move in proposedMoves)
        //    //                {
        //    //                    if (Cells.Exists(c => (c.Piece != null) && (c.X == move.X && c.Y == move.Y)))
        //    //                    {

        //    //                    }
        //    //                }
        //    //        }
        //    //}
        //}
    }
}
