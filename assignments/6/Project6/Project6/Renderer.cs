using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    public class Renderer
    {

        public void Render(List<Piece> pieces)
        {
            foreach ( Piece piece in pieces)
            {
                if (piece.Visible)
                {
                    Console.SetCursorPosition(piece.X, piece.Y);
                    Console.Write(piece.Letter);
                }
                else
                {

                }

            }

        }
    }
}
