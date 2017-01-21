using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces.Testing
{
    public class ChessCalculations
    {
        public static int GetTotalPossibleMoves(Board board, Color color)
        {
            List<Cell> pieces = new List<Cell>();

            foreach (var cell in board.CellsA)
            {
                if (cell.Piece != null && cell.Piece.Color == color)
                {
                    pieces.Add(cell);
                }
            }

            List<Move> allPossibleMoves = new List<Move>();

            foreach (var piece in pieces)
            {
                allPossibleMoves.AddRange(board.FilterMoves(piece));
            }

            return allPossibleMoves.Count;
        }
    }
}
