using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var board = new Board();
            board.InitBoard();

            var renderer = new Renderer();
            renderer.Render(board);

            //renderer.RenderMove(board.Cells.Find(c => (c.X == board.X) && (c.Y == board.Y)).Piece, board);

            Console.ReadKey(true);
        }
    }
}
