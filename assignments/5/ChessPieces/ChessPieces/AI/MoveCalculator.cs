using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces.AI
{
    public class MoveCalculator
    {
        public static void TestingTopLevelBoard(Board board)
        {
            foreach (var topLevelCell in board.CellsA)
            {
                if (topLevelCell.Piece != null)
                {
                    topLevelCell.Piece.PossibleMoves.AddRange(FilterMoves(topLevelCell.Piece));

                    if (topLevelCell.Piece.PossibleMoves.Count > 0)
                    {
                        topLevelCell.Piece.Boards = new Cell[topLevelCell.Piece.PossibleMoves.Count][,];

                        for (int move = 0; move < topLevelCell.Piece.PossibleMoves.Count; move++)
                        {
                            topLevelCell.Piece.Boards[move] = new Cell[8, 8];

                            foreach (var presentBoardCell in topLevelCell.Piece.PresentBoard)
                            {
                                topLevelCell.Piece.Boards[move][presentBoardCell.X, presentBoardCell.Y] = new ChessPieces.Cell()
                                {
                                    X = presentBoardCell.X,
                                    Y = presentBoardCell.Y,
                                    Piece = presentBoardCell.Piece
                                };
                            }

                            topLevelCell.Piece.Boards[move][topLevelCell.X, topLevelCell.Y].Piece = null;
                            topLevelCell.Piece.Boards[move][topLevelCell.Piece.PossibleMoves[move].X, topLevelCell.Piece.PossibleMoves[move].Y].Piece = new Piece()
                            {
                                X = topLevelCell.Piece.PossibleMoves[move].X,
                                Y = topLevelCell.Piece.PossibleMoves[move].Y,
                                Type = topLevelCell.Piece.Type,
                                ID = topLevelCell.Piece.ID
                            };
                        }
                    }
                }
            }
        }

        public static void _Testing(Piece piece)
        {
            foreach (var cell in piece.PresentBoard)
            {
                if (cell.Piece != null)
                {
                    cell.Piece.PossibleMoves.AddRange(FilterMoves(cell.Piece));

                    if (cell.Piece.PossibleMoves.Count > 0)
                    {
                        cell.Piece.Boards = new Cell[cell.Piece.PossibleMoves.Count][,];

                        for (int i = 0; i < cell.Piece.PossibleMoves.Count; i++)
                        {
                            cell.Piece.Boards[i] = new Cell[8, 8];

                            foreach (var c in piece.PresentBoard)
                            {
                                cell.Piece.Boards[i][c.X, c.Y] = new Cell()
                                {
                                    X = c.X,
                                    Y = c.Y,
                                    Piece = new Piece()
                                    {
                                        X = c.Piece.X,
                                        Y = c.Piece.Y,
                                        ID = c.Piece.ID,
                                        Color = c.Piece.Color,

                                    }
                                };
                            }

                            cell.Piece.Boards[i][cell.Piece.X, cell.Piece.Y].Piece = null;
                            cell.Piece.Boards[i][cell.Piece.PossibleMoves[i].X, cell.Piece.PossibleMoves[i].Y].Piece = new Piece()
                            {
                                X = cell.Piece.PossibleMoves[i].X,
                                Y = cell.Piece.PossibleMoves[i].Y,
                                Type = cell.Piece.Type,
                                ID = cell.Piece.ID,
                                Color = cell.Piece.Color,
                                PresentBoard = new Cell[8, 8]
                            };

                            foreach (var c in cell.Piece.Boards[i][cell.Piece.PossibleMoves[i].X, cell.Piece.PossibleMoves[i].Y].Piece.Boards[i])
                            {
                                cell.Piece.Boards[i][cell.Piece.PossibleMoves[i].X, cell.Piece.PossibleMoves[i].Y].Piece.PresentBoard[c.X, c.Y] = new Cell()
                                {
                                    X = c.X,
                                    Y = c.Y,
                                    Piece = c.Piece
                                };
                            }
                        }
                    }
                }
            }
        }

        public static List<Move> FilterMoves(Piece piece)
        {
            List<Move> proposedMoves = new List<Move>();

            switch (piece.Type)
            {
                case Type.Pawn:
                    #region Pawn
                    if (piece.Color == Color.White) // White pawns can only move up the board
                    {
                        if (piece.Y == (int)Limit.Upper) // Check if the white pawn reached the other side of the board
                        {
                            piece.PresentBoard[piece.X, piece.Y].Piece = new Rook() { X = piece.X, Y = piece.Y, Color = Color.White }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                            break;
                        }

                        if (piece.Y == 6) // Pawns can move two spaces on their first move
                        {
                            if (piece.PresentBoard[piece.X, piece.Y - 2].Piece == null) // As long as there isn't a piece two spaces ahead
                            {
                                proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 2 }); // Add the move
                            }
                        }

                        if (piece.PresentBoard[piece.X, piece.Y - 1].Piece == null) // As long as there isn't a piece one space ahead
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 1 }); // Add the move
                        }

                        if (piece.X < 7)
                        {
                            if (piece.PresentBoard[piece.X + 1, piece.Y - 1].Piece != null &&
                                piece.PresentBoard[piece.X + 1, piece.Y - 1].Piece.Color == Color.Black)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1, Takeable = true });
                            }
                        }

                        if (piece.X > 0)
                        {
                            if (piece.PresentBoard[piece.X - 1, piece.Y - 1].Piece != null &&
                                piece.PresentBoard[piece.X - 1, piece.Y - 1].Piece.Color == Color.Black)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1, Takeable = true });
                            }
                        }
                    }
                    if (piece.Color == Color.Black) // Black pawns can only move down the board
                    {
                        if (piece.Y == (int)Limit.Lower) // Check if the black pawn reached the other side of the board
                        {
                            piece.PresentBoard[piece.X, piece.Y].Piece = new Rook() { X = piece.X, Y = piece.Y, Color = Color.Black }; // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                            break;
                        }
                        else if (piece.Y == 1) // Pawns can move two spaces on their first move
                        {
                            if (piece.PresentBoard[piece.X, piece.Y + 2].Piece == null) // As long as there isn't a piece two spaces ahead
                            {
                                proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 2 }); // Add the move
                            }
                        }

                        if (piece.PresentBoard[piece.X, piece.Y + 1].Piece == null) // As long as there isn't a piece one space ahead
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 1 }); // Add the move
                        }

                        if (piece.X < 7)
                        {
                            if (piece.PresentBoard[piece.X + 1, piece.Y + 1].Piece != null &&
                                piece.PresentBoard[piece.X + 1, piece.Y + 1].Piece.Color == Color.White)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1, Takeable = true });
                            }
                        }

                        if (piece.X > 0)
                        {
                            if (piece.PresentBoard[piece.X - 1, piece.Y + 1].Piece != null &&
                                piece.PresentBoard[piece.X - 1, piece.Y + 1].Piece.Color == Color.White)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1, Takeable = true });
                            }
                        }

                    }
                    return proposedMoves;
                #endregion Pawn
                case Type.Rook:
                    #region Rook
                    #region Upward iteration
                    for (int height = 1; height <= piece.Y; height++)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y - height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - height });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y - height].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Downward iteration
                    for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y + height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + height });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y + height].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Leftward iteration
                    for (int width = 1; width <= piece.X; width++)
                    {
                        if (piece.PresentBoard[piece.X - width, piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X - width, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = piece.X - width, Y = piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Rightward iteration
                    for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                    {
                        if (piece.PresentBoard[piece.X + width, piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X + width, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = piece.X + width, Y = piece.Y, Takeable = true });
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
                    if (piece.Y > 0)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y - 1].Piece == null) // Check space above is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 1 });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y - 1].Piece.Color != piece.Color) // If not empty, if the piece of an opposite color
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 1, Takeable = true });
                        }
                    }

                    if (piece.Y < 7)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y + 1].Piece == null) // Check space below is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 1 });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y + 1].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 1, Takeable = true });
                        }
                    }

                    if (piece.X > 0)
                    {
                        if (piece.PresentBoard[piece.X - 1, piece.Y].Piece == null) // Check space to left is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X - 1, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y, Takeable = true });
                        }
                    }

                    if (piece.X < 7)
                    {
                        if (piece.PresentBoard[piece.X + 1, piece.Y].Piece == null) // Check space to right is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X + 1, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y, Takeable = true });
                        }
                    }

                    if (piece.X > 0 && piece.Y > 0)
                    {
                        if (piece.PresentBoard[piece.X - 1, piece.Y - 1].Piece == null) // Check up left is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1 });
                        }
                        else if (piece.PresentBoard[piece.X - 1, piece.Y - 1].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1, Takeable = true });
                        }
                    }

                    if (piece.X > 0 && piece.Y < 7)
                    {
                        if (piece.PresentBoard[piece.X - 1, piece.Y + 1].Piece == null) // Check down left is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1 });
                        }
                        else if (piece.PresentBoard[piece.X - 1, piece.Y + 1].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1, Takeable = true });
                        }
                    }

                    if (piece.X < 7 && piece.Y > 0)
                    {
                        if (piece.PresentBoard[piece.X + 1, piece.Y - 1].Piece == null) // Check up right is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1 });
                        }
                        else if (piece.PresentBoard[piece.X + 1, piece.Y - 1].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1, Takeable = true });
                        }
                    }

                    if (piece.X < 7 && piece.Y < 7)
                    {
                        if (piece.PresentBoard[piece.X + 1, piece.Y + 1].Piece == null) // Check down right is empty
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1 });
                        }
                        else if (piece.PresentBoard[piece.X + 1, piece.Y + 1].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1, Takeable = true });
                        }
                    }
                    return proposedMoves;
                #endregion King
                case Type.Queen:
                    #region Queen
                    #region Upward iteration
                    for (int height = 1; height <= piece.Y; height++)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y - height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - height });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y - height].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Downward iteration
                    for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                    {
                        if (piece.PresentBoard[piece.X, piece.Y + height].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + height });
                        }
                        else if (piece.PresentBoard[piece.X, piece.Y + height].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + height, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Leftward iteration
                    for (int width = 1; width <= piece.X; width++)
                    {
                        if (piece.PresentBoard[piece.X - width, piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X - width, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = piece.X - width, Y = piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Rightward iteration
                    for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                    {
                        if (piece.PresentBoard[piece.X + width, piece.Y].Piece == null)
                        {
                            proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y });
                        }
                        else if (piece.PresentBoard[piece.X + width, piece.Y].Piece.Color != piece.Color)
                        {
                            proposedMoves.Add(new ChessPieces.Move() { X = piece.X + width, Y = piece.Y, Takeable = true });
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    #endregion
                    #region Up left iteration
                    if (piece.X <= piece.Y)
                    {
                        for (int width = 1; width <= piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X - width, piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y - width });
                            }
                            else if (piece.PresentBoard[piece.X - width, piece.Y - width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y - width, Takeable = true });
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
                        for (int height = 1; height <= piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X - height, piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y - height });
                            }
                            else if (piece.PresentBoard[piece.X - height, piece.Y - height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y - height, Takeable = true });
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
                    if (piece.X <= (int)Limit.Size - piece.Y)
                    {
                        for (int height = 1; height <= piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X + height, piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y - height });
                            }
                            else if (piece.PresentBoard[piece.X + height, piece.Y - height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y - height, Takeable = true });
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
                        for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X + width, piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y - width });
                            }
                            else if (piece.PresentBoard[piece.X + width, piece.Y - width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y - width, Takeable = true });
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
                    if (piece.X >= piece.Y)
                    {
                        for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X + width, piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y + width });
                            }
                            else if (piece.PresentBoard[piece.X + width, piece.Y + width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y + width, Takeable = true });
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
                        for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X + height, piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y + height });
                            }
                            else if (piece.PresentBoard[piece.X + height, piece.Y + height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y + height, Takeable = true });
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
                    if (piece.X <= (int)Limit.Size - piece.Y)
                    {
                        for (int width = 1; width <= piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X - width, piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y + width });
                            }
                            else if (piece.PresentBoard[piece.X - width, piece.Y + width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y + width, Takeable = true });
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
                        for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X - height, piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y + height });
                            }
                            else if (piece.PresentBoard[piece.X - height, piece.Y + height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y + height, Takeable = true });
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
                    if (piece.X <= piece.Y)
                    {
                        for (int width = 1; width <= piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X - width, piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y - width });
                            }
                            else if (piece.PresentBoard[piece.X - width, piece.Y - width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y - width, Takeable = true });
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
                        for (int height = 1; height <= piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X - height, piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y - height });
                            }
                            else if (piece.PresentBoard[piece.X - height, piece.Y - height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y - height, Takeable = true });
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
                    if (piece.X <= (int)Limit.Size - piece.Y)
                    {
                        for (int height = 1; height <= piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X + height, piece.Y - height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y - height });
                            }
                            else if (piece.PresentBoard[piece.X + height, piece.Y - height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y - height, Takeable = true });
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
                        for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X + width, piece.Y - width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y - width });
                            }
                            else if (piece.PresentBoard[piece.X + width, piece.Y - width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y - width, Takeable = true });
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
                    if (piece.X >= piece.Y)
                    {
                        for (int width = 1; width <= (int)Limit.Size - piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X + width, piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y + width });
                            }
                            else if (piece.PresentBoard[piece.X + width, piece.Y + width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + width, Y = piece.Y + width, Takeable = true });
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X + height, piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y + height });
                            }
                            else if (piece.PresentBoard[piece.X + height, piece.Y + height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + height, Y = piece.Y + height, Takeable = true });
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    #region Down left iteration
                    if (piece.X <= (int)Limit.Size - piece.Y)
                    {
                        for (int width = 1; width <= piece.X; width++)
                        {
                            if (piece.PresentBoard[piece.X - width, piece.Y + width].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y + width });
                            }
                            else if (piece.PresentBoard[piece.X - width, piece.Y + width].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - width, Y = piece.Y + width, Takeable = true });
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
                        for (int height = 1; height <= (int)Limit.Size - piece.Y; height++)
                        {
                            if (piece.PresentBoard[piece.X - height, piece.Y + height].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y + height });
                            }
                            else if (piece.PresentBoard[piece.X - height, piece.Y + height].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X - height, Y = piece.Y + height, Takeable = true });
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
                        if (piece.X + i - 3 > -1 && piece.X + i - 3 <= (int)Limit.Size &&
                            piece.Y + i > -1 && piece.Y + i <= (int)Limit.Size)
                        {
                            if (piece.PresentBoard[piece.X + i - 3, piece.Y + i].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i - 3, Y = piece.Y + i });
                            }
                            else if (piece.PresentBoard[piece.X + i - 3, piece.Y + i].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i - 3, Y = piece.Y + i, Takeable = true });
                            }
                        }


                        if (piece.X + i - 3 > -1 && piece.X + i - 3 <= (int)Limit.Size &&
                            piece.Y + i * -1 > -1 && piece.Y + i * -1 <= (int)Limit.Size)
                        {
                            if (piece.PresentBoard[piece.X + i - 3, piece.Y + i * -1].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i - 3, Y = piece.Y + i * -1 });
                            }
                            else if (piece.PresentBoard[piece.X + i - 3, piece.Y + i * -1].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i - 3, Y = piece.Y + i * -1, Takeable = true });
                            }
                        }

                        if (piece.X + i > -1 && piece.X + i <= (int)Limit.Size &&
                            piece.Y + i - 3 > -1 && piece.Y + i - 3 <= (int)Limit.Size)
                        {
                            if (piece.PresentBoard[piece.X + i, piece.Y + i - 3].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i, Y = piece.Y + i - 3 });
                            }
                            else if (piece.PresentBoard[piece.X + i, piece.Y + i - 3].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i, Y = piece.Y + i - 3, Takeable = true });
                            }
                        }

                        if (piece.X + i > -1 && piece.X + i <= (int)Limit.Size &&
                            piece.Y + (i - 3) * -1 > -1 && piece.Y + (i - 3) * -1 <= (int)Limit.Size)
                        {
                            if (piece.PresentBoard[piece.X + i, piece.Y + (i - 3) * -1].Piece == null)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i, Y = piece.Y + (i - 3) * -1 });
                            }
                            else if (piece.PresentBoard[piece.X + i, piece.Y + (i - 3) * -1].Piece.Color != piece.Color)
                            {
                                proposedMoves.Add(new Move() { X = piece.X + i, Y = piece.Y + (i - 3) * -1, Takeable = true });
                            }
                        }
                    }
                    return proposedMoves;
                    #endregion
            }

            return proposedMoves;
        }
        
    }
}
