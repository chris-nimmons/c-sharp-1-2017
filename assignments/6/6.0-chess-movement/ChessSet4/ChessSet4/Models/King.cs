using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public class King : ChessPiece, IRenderable
    {
        //public bool Visible { get; set; }
        //public string Letter { get; set; }
        //public char Index { get; set; }
        //public int X { get; set; }
        //public int Y { get; set; }
        //public bool MoveAllow { get; set; }

        public override List<Move> GetMoves()
        {
            List<Move> possibleMoves = new List<Move>();
            for (int i = 0; i < 2; i++)
            {
                possibleMoves.Add(new Move { X = X + i, Y = Y });
                possibleMoves.Add(new Move { X = X, Y = Y + i });
                possibleMoves.Add(new Move { X = X, Y = Y - i });
                possibleMoves.Add(new Move { X = X - i, Y = Y });
                possibleMoves.Add(new Move { X = X - i, Y = Y + i });
                possibleMoves.Add(new Move { X = X + i, Y = Y + i });
                possibleMoves.Add(new Move { X = X + i, Y = Y - i });
                possibleMoves.Add(new Move { X = X - i, Y = Y - i });
            }

            return possibleMoves;
        }

        public King()
        {
            Letter = 'K';
        }
        //public void Render()
        //{
        //    Console.SetCursorPosition(X, Y);
        //    Console.Write("K");
        //}
    }
}
