using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public class Pawn : ChessPiece, IRenderable 
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

            possibleMoves.Add(new Move { X = X, Y = Y - 1 });

            possibleMoves.Add(new Move { X = X, Y = Y });


            //for (int i = 0; i < 2; i++)
            //{
                
            //}
            //List<Move> movesAllow = new List<Move>();
            return possibleMoves;
        }


        public Pawn()
        {
            Letter = 'P';
        }
        //public void Render()
        //{
        //    Console.SetCursorPosition(X, Y);
        //    Console.Write("P");
        //}

    }
}
