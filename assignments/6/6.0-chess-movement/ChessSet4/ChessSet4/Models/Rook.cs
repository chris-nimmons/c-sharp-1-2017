using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    class Rook : ChessPiece, IRenderable
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
            for (int i = 0; i < 8; i++)
            {
                possibleMoves.Add(new Move {X = X + i, Y = Y });
                possibleMoves.Add(new Move {X = X, Y = Y + i });
                possibleMoves.Add(new Move {X = X, Y = Y - i });
                possibleMoves.Add(new Move {X = X - i, Y = Y });
            }
            return possibleMoves;
        }

        public Rook()
        {
            Letter = 'R';
        }
        //public void Render()
        //{
        //    Console.SetCursorPosition(X, Y);
        //    Console.Write("R");
        //}
    }
}
