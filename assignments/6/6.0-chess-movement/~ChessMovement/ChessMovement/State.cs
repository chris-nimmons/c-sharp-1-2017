using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMovement
{
    public class State
    {
        public Piece[] Pieces { get; set; }
        public Cell[,] Board { get; set; }
        public int Turn { get; set; }
        public Node[] Nodes { get; set; }
        public Color CurrentColor
        {
            get
            {
                if (Turn % 2 == 1)
                {
                    return Color.White;
                }
                else
                {
                    return Color.Black;
                }
            }
        }
        public List<Move> PossibleMoves
        {
            get
            {
                return GetAllMoves();
            }
        }
        public int PossibleResults
        {
            get
            {
                return PossibleMoves.Count;
            }
        }
        public int PossibleNodes { get
            {
                int moves = 0;

                if (Nodes != null)
                {
                    foreach (var node in Nodes)
                    {
                        moves += node.PossibleMoves.Count;
                    }
                }

                return moves;
            } }

        public State(int turn, Piece[] pieces)
        {
            Turn = turn;

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Piece, Piece>());
            Pieces = AutoMapper.Mapper.Map<Piece[], Piece[]>(pieces);
        }

        public void PopulateBoard()
        {
            Board = new Cell[8, 8];

            foreach (var piece in Pieces.Where(p => !p.Taken))
            {
                Board[piece.X, piece.Y] = new Cell()
                {
                    X = piece.X,
                    Y = piece.Y,
                    PieceId = piece.ID
                };
            }
        }

        public void BranchNode(int currentDepth, int finalDepth, ref int totalCurrentNodes, int points)
        {
            var renderer = new Renderer(0, 0);

            var allMoves = GetAllMoves();
            var totalNodes = allMoves.Count;

            Nodes = new Node[totalNodes];
            for (int i = 0; i < totalNodes; i++)
            {
                Nodes[i] = new Node(Turn + 1, Pieces, allMoves[i], currentDepth + 1, finalDepth, ref totalCurrentNodes, points);
            }

            allMoves = null;
        }

        public List<Move> GetAllMoves()
        {
            PopulateBoard();

            var moves = new List<Move>();

            foreach (var piece in Pieces.Where(p => p.Color == CurrentColor && !p.Taken))
            {
                moves.AddRange(GetMoves(piece));
            }

            return moves;
        }

        public List<Move> GetMoves(Piece piece)
        {
            if (!piece.Taken)
            {
                switch (piece.Type)
                {
                    case PieceType.Pawn:
                        return GetPawnMoves(piece);
                    case PieceType.Rook:
                        return GetRookMoves(piece);
                    case PieceType.Night:
                         return GetKnightMoves(piece);
                    case PieceType.Bishop:
                        return GetBishopMoves(piece);
                    case PieceType.Queen:
                        return GetQueenMoves(piece);
                    case PieceType.King:
                        return GetKingMoves(piece);
                }
            }

            return null;
        }

        public List<Move> GetPawnMoves(Piece piece)
        {
            var moves = new List<Move>();

            if (CurrentColor == Color.White) // White pawns can only move up the board
            {
                if (piece.Y == 0) // Check if the white pawn reached the other side of the board
                {
                    // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                }

                if (piece.X < 7 && piece.Y > 0)
                {
                    if (Board[piece.X + 1, piece.Y - 1] != null && (int)Board[piece.X + 1, piece.Y - 1].PieceId < 16)
                    {
                        moves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1, Takeable = true, ID = piece.ID });
                    }
                }

                if (piece.X > 0 && piece.Y > 0)
                {
                    if (Board[piece.X - 1, piece.Y - 1] != null && (int)Board[piece.X - 1, piece.Y - 1].PieceId < 16)
                    {
                        moves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1, Takeable = true, ID = piece.ID });
                    }
                }

                if (piece.Y == 6) // Pawns can move two spaces on their first move
                {
                    if (Board[piece.X, piece.Y - 2] == null && Board[piece.X, piece.Y - 1] == null) // As long as there isn't a piece two spaces ahead
                    {
                        moves.Add(new Move() { X = piece.X, Y = piece.Y - 2, ID = piece.ID, Takeable = false }); // Add the move
                    }
                }

                if (piece.Y > 0 && Board[piece.X, piece.Y - 1] == null) // As long as there isn't a piece one space ahead
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y - 1, ID = piece.ID, Takeable = false }); // Add the move
                }

            }
            if (CurrentColor == Color.Black) // Black pawns can only move down the board
            {
                if (piece.Y == 0) // Check if the black pawn reached the other side of the board
                {
                    // Replace the pawn with a Rook -- This needs to be changed to trigger a selection event where the user can choose between a Rook, Bishop, Knight or Queen
                }

                if (piece.X < 7 && piece.Y < 7)
                {
                    if (Board[piece.X + 1, piece.Y + 1] != null && (int)Board[piece.X + 1, piece.Y + 1].PieceId > 15)
                    {
                        moves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1, Takeable = true, ID = piece.ID });
                    }
                }

                if (piece.X > 0 && piece.Y < 7)
                {
                    if (Board[piece.X - 1, piece.Y + 1] != null && (int)Board[piece.X - 1, piece.Y + 1].PieceId > 15)
                    {
                        moves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1, Takeable = true, ID = piece.ID });
                    }
                }

                if (piece.Y == 1) // Pawns can move two spaces on their first move
                {
                    if (Board[piece.X, piece.Y + 2] == null && Board[piece.X, piece.Y + 1] == null) // As long as there isn't a piece two spaces ahead
                    {
                        moves.Add(new Move() { X = piece.X, Y = piece.Y + 2, ID = piece.ID, Takeable = false }); // Add the move
                    }
                }

                if (piece.Y < 7 && Board[piece.X, piece.Y + 1] == null) // As long as there isn't a piece one space ahead
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y + 1, ID = piece.ID, Takeable = false }); // Add the move
                }

            }
            return moves;
        }

        public List<Move> GetRookMoves(Piece piece)
        {
            var moves = new List<Move>();

            #region Upward iteration
            for (int height = 1; height <= piece.Y; height++)
            {
                if (Board[piece.X, piece.Y - height] == null)
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y - height, ID = piece.ID });
                }
                else if (Board[piece.X, piece.Y - height].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y - height, Takeable = true, ID = piece.ID });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Downward iteration
            for (int height = 1; height <= 7 - piece.Y; height++)
            {
                if (Board[piece.X, piece.Y + height] == null)
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y + height, ID = piece.ID });
                }
                else if (Board[piece.X, piece.Y + height].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X, Y = piece.Y + height, Takeable = true, ID = piece.ID });
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
                if (Board[piece.X -width, piece.Y] == null)
                {
                    moves.Add(new Move() { X = piece.X -width, Y = piece.Y, ID = piece.ID });
                }
                else if (Board[piece.X -width, piece.Y].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X -width, Y = piece.Y, Takeable = true, ID = piece.ID });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion
            #region Rightward iteration
            for (int width = 1; width <= 7 - piece.X; width++)
            {
                if (Board[piece.X + width, piece.Y] == null)
                {
                    moves.Add(new Move() { X = piece.X + width, Y = piece.Y, ID = piece.ID });
                }
                else if (Board[piece.X + width, piece.Y].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X + width, Y = piece.Y, Takeable = true, ID = piece.ID });
                    break;
                }
                else
                {
                    break;
                }
            }
            #endregion

            return moves;
        }

        public List<Move> GetKnightMoves(Piece piece)
        {
            var moves = new List<Move>();

            if (piece.X - 2 > -1 && piece.Y - 1 > -1)
            {
                if (Board[piece.X - 2, piece.Y - 1] == null)
                {
                    moves.Add(new Move() { X = piece.X - 2, Y = piece.Y - 1, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X - 2, piece.Y - 1].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X - 2, Y = piece.Y - 1, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X - 2 > -1 && piece.Y + 1 < 8)
            { 
                if (Board[piece.X - 2, piece.Y + 1] == null)
                {
                    moves.Add(new Move() { X = piece.X - 2, Y = piece.Y + 1, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X - 2, piece.Y + 1].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X - 2, Y = piece.Y + 1, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X - 1 > -1 && piece.Y -2 > -1)
            {
                if (Board[piece.X - 1, piece.Y - 2] == null)
                {
                    moves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 2, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X - 1, piece.Y - 2].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 2, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X - 1 > -1 && piece.Y + 2 < 8)
            {
                if (Board[piece.X - 1, piece.Y + 2] == null)
                {
                    moves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 2, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X - 1, piece.Y + 2].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 2, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X + 1 < 8 && piece.Y - 2 > -1)
            {
                if (Board[piece.X + 1, piece.Y - 2] == null)
                {
                    moves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 2, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X + 1, piece.Y - 2].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 2, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X + 1 < 8 && piece.Y + 2 < 8)
            {
                if (Board[piece.X + 1, piece.Y + 2] == null)
                {
                    moves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 2, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X + 1, piece.Y + 2].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 2, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X + 2 < 8 && piece.Y - 1 > -1)
            {
                if (Board[piece.X + 2, piece.Y - 1] == null)
                {
                    moves.Add(new Move() { X = piece.X + 2, Y = piece.Y - 1, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X + 2, piece.Y - 1].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X + 2, Y = piece.Y - 1, ID = piece.ID, Takeable = true });
                }
            }

            if (piece.X + 2 < 8 && piece.Y + 1 < 8)
            {
                if (Board[piece.X + 2, piece.Y + 1] == null)
                {
                    moves.Add(new Move() { X = piece.X + 2, Y = piece.Y + 1, ID = piece.ID, Takeable = false });
                }
                else if (Board[piece.X + 2, piece.Y + 1].Color != CurrentColor)
                {
                    moves.Add(new Move() { X = piece.X + 2, Y = piece.Y + 1, ID = piece.ID, Takeable = true });
                }
            }

            return moves;
        }

        public List<Move> GetBishopMoves(Piece piece)
        {
            var moves = new List<Move>();

            #region Up left iteration
            if (piece.X <= piece.Y)
            {
                for (int width = 1; width <= piece.X; width++)
                {
                    if (Board[piece.X - width, piece.Y - width] == null)
                    {
                        moves.Add(new Move() { X = piece.X - width, Y = piece.Y - width, ID = piece.ID });
                    }
                    else if (Board[piece.X - width, piece.Y - width].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X - width, Y = piece.Y - width, Takeable = true, ID = piece.ID });
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
                    if (Board[piece.X - height, piece.Y - height] == null)
                    {
                        moves.Add(new Move() { X = piece.X - height, Y = piece.Y - height, ID = piece.ID });
                    }
                    else if (Board[piece.X - height, piece.Y - height].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X - height, Y = piece.Y - height, Takeable = true, ID = piece.ID });
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
            if (piece.X <= 7 - piece.Y)
            {
                for (int height = 1; height <= piece.Y; height++)
                {
                    if (Board[piece.X + height, piece.Y - height] == null)
                    {
                        moves.Add(new Move() { X = piece.X + height, Y = piece.Y - height, ID = piece.ID });
                    }
                    else if (Board[piece.X + height, piece.Y - height].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X + height, Y = piece.Y - height, Takeable = true, ID = piece.ID });
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
                for (int width = 1; width <= 7 - piece.X; width++)
                {
                    if (Board[piece.X + width, piece.Y - width] == null)
                    {
                        moves.Add(new Move() { X = piece.X + width, Y = piece.Y - width, ID = piece.ID });
                    }
                    else if (Board[piece.X + width, piece.Y - width].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X + width, Y = piece.Y - width, Takeable = true, ID = piece.ID });
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
                for (int width = 1; width <= 7 - piece.X; width++)
                {
                    if (Board[piece.X + width, piece.Y + width] == null)
                    {
                        moves.Add(new Move() { X = piece.X + width, Y = piece.Y + width, ID = piece.ID });
                    }
                    else if (Board[piece.X + width, piece.Y + width].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X + width, Y = piece.Y + width, Takeable = true, ID = piece.ID });
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
                for (int height = 1; height <= 7 - piece.Y; height++)
                {
                    if (Board[piece.X + height, piece.Y + height] == null)
                    {
                        moves.Add(new Move() { X = piece.X + height, Y = piece.Y + height, ID = piece.ID });
                    }
                    else if (Board[piece.X + height, piece.Y + height].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X + height, Y = piece.Y + height, Takeable = true, ID = piece.ID });
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
            if (piece.X <= 7 - piece.Y)
            {
                for (int width = 1; width <= piece.X; width++)
                {
                    if (Board[piece.X - width, piece.Y + width] == null)
                    {
                        moves.Add(new Move() { X = piece.X - width, Y = piece.Y + width, ID = piece.ID });
                    }
                    else if (Board[piece.X - width, piece.Y + width].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X - width, Y = piece.Y + width, Takeable = true, ID = piece.ID });
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
                for (int height = 1; height <= 7 - piece.Y; height++)
                {
                    if (Board[piece.X - height, piece.Y + height] == null)
                    {
                        moves.Add(new Move() { X = piece.X - height, Y = piece.Y + height, ID = piece.ID });
                    }
                    else if (Board[piece.X - height, piece.Y + height].Color != CurrentColor)
                    {
                        moves.Add(new Move() { X = piece.X - height, Y = piece.Y + height, Takeable = true, ID = piece.ID });
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion

            return moves;
        }

        public List<Move> GetQueenMoves(Piece piece)
        {
            var moves = new List<Move>();

            moves.AddRange(GetBishopMoves(piece));
            moves.AddRange(GetRookMoves(piece));

            return moves;
        }

        public List<Move> GetKingMoves(Piece piece)
        {
            var proposedMoves = new List<Move>();

            if (piece.Y > 0)
            {
                if (Board[piece.X, piece.Y - 1] == null) // Check space above is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 1, ID = piece.ID });
                }
                else if (Board[piece.X, piece.Y - 1].Color != CurrentColor) // If not empty, if the piece of an opposite color
                {
                    proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y - 1, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.Y < 7)
            {
                if (Board[piece.X, piece.Y + 1] == null) // Check space below is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 1, ID = piece.ID });
                }
                else if (Board[piece.X, piece.Y + 1].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X, Y = piece.Y + 1, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X > 0)
            {
                if (Board[piece.X - 1, piece.Y] == null) // Check space to left is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y, ID = piece.ID });
                }
                else if (Board[piece.X - 1, piece.Y].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X < 7)
            {
                if (Board[piece.X + 1, piece.Y] == null) // Check space to right is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y, ID = piece.ID });
                }
                else if (Board[piece.X + 1, piece.Y].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X > 0 && piece.Y > 0)
            {
                if (Board[piece.X - 1, piece.Y - 1] == null) // Check up left is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1, ID = piece.ID });
                }
                else if (Board[piece.X - 1, piece.Y - 1].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y - 1, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X > 0 && piece.Y < 7)
            {
                if (Board[piece.X - 1, piece.Y + 1] == null) // Check down left is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1, ID = piece.ID });
                }
                else if (Board[piece.X - 1, piece.Y + 1].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X - 1, Y = piece.Y + 1, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X < 7 && piece.Y > 0)
            {
                if (Board[piece.X + 1, piece.Y - 1] == null) // Check up right is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1, ID = piece.ID });
                }
                else if (Board[piece.X + 1, piece.Y - 1].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y - 1, Takeable = true, ID = piece.ID });
                }
            }

            if (piece.X < 7 && piece.Y < 7)
            {
                if (Board[piece.X + 1, piece.Y + 1] == null) // Check down right is empty
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1, ID = piece.ID });
                }
                else if (Board[piece.X + 1, piece.Y + 1].Color != CurrentColor)
                {
                    proposedMoves.Add(new Move() { X = piece.X + 1, Y = piece.Y + 1, Takeable = true, ID = piece.ID });
                }
            }
            return proposedMoves;

        }
    }
}