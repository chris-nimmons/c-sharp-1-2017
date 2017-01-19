using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    public class Renderer
    {
        public void Render(Board board)
        {
            foreach (var cell in board.CellsA)
            {
                Console.SetCursorPosition(cell.X, cell.Y);
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

        //public void RenderMove(IPiece piece, Board board)
        //{
        //    Cell cell;
        //    foreach (var move in piece.GetMoves())
        //    {
        //        cell = board.CellsList.Find(c => (c.X == move.X + 1) && (c.Y == move.Y));
        //        Console.SetCursorPosition(move.X, move.Y);
        //        Console.BackgroundColor = cell.Color;
        //        Console.ForegroundColor = (ConsoleColor)piece.Color;
        //        Console.Write('x');
        //    }
        //}
    }
}