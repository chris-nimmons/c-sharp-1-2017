using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessPieces;

namespace ChessCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.InitBoard();

            var program = new Program();

            Console.WriteLine("Total possible moves for white player: {0}",
                              program.GetTotalPossibleMoves(board, Color.White));
            Console.WriteLine("Total possible moves for black player: {0}",
                              program.GetTotalPossibleMoves(board, Color.Black));

            Console.ReadKey(true);
        }

        public int GetTotalPossibleMoves(Board board, Color color)
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
