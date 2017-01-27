using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Renderer
    {
        public void Render(List<Piece> pieces)
        {
            foreach (var piece in pieces)
            {
                Console.SetCursorPosition(piece.X, piece.Y);
                Console.Write(piece.Letter);
            }

        }
    }
}
