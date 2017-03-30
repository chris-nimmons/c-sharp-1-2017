using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public class Knight : ChessPiece, IRenderable
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
                possibleMoves.Add(new Move { X = X - 1, Y = Y - 3 });
                possibleMoves.Add(new Move { X = X - 1, Y = Y + 3 });
                possibleMoves.Add(new Move { X = X + 1, Y = Y - 3 });
                possibleMoves.Add(new Move { X = X + 3, Y = Y + 1 });
                possibleMoves.Add(new Move { X = X + 3, Y = Y - 1 });
                possibleMoves.Add(new Move { X = X - 3, Y = Y + 1});
                possibleMoves.Add(new Move { X = X - 3, Y = Y - 1 });
            }
            return possibleMoves;
            //what this does is add possible mvoes from the Knight into the list GetMoves
        }

        public Knight()
        {
            Letter = 'k';
        }

        //public void Render()
        //{
        //    Console.SetCursorPosition(X, Y);
        //    Console.Write("k");
        //}

    }
}
