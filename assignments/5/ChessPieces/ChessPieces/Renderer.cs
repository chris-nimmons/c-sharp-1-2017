using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPieces.Testing;

namespace ChessPieces
{
    public class Renderer
    {
        public int XOffset { get; set; }
        public int YOffset { get; set; }

        public Renderer(int x = 10, int y = 5)
        {
            XOffset = x;
            YOffset = y;
        }

        public void Render(Board board)
        {
            foreach (var cell in board.CellsA)
            {
                Console.SetCursorPosition(cell.X + XOffset, cell.Y + YOffset);
                Console.BackgroundColor = cell.Color;
                if (cell.Piece != null)
                {
                    Console.ForegroundColor = (ConsoleColor)cell.Piece.Color;
                    Console.Write((char)cell.Piece.Type);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(' ');
                }
            }
        }

        public void RenderMove(Cell cell, Board board)
        {
            foreach (var move in board.FilterMoves(cell))
            {
                Console.SetCursorPosition(move.X + XOffset, move.Y + YOffset);
                Console.BackgroundColor = board.CellsA[(int)Limit.Right - move.X, (int)Limit.Lower - move.Y].Color;
                if (move.Takeable)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = (ConsoleColor)cell.Piece.Color;
                }
                Console.Write('x');
            }
        }

        public void RenderStats(Board board)
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("Total possible moves for white: {0}",
                ChessCalculations.GetTotalPossibleMoves(board, Color.White));
            Console.WriteLine("Total possible moves for black: {0}",
                ChessCalculations.GetTotalPossibleMoves(board, Color.Black));
        }
    }
}