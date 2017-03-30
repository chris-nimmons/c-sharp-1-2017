using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
   public class Move : IRenderable
    {

        public bool Visible { get; set; }
        //public string Letter { get; set; }
        public char Letter { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        
        public Move() // (int X, int Y)
        {
            Visible = true;
            Letter = '#';

            //this.X = X;
            //this.Y = Y;
        }

       

        //public void Render()
        //{
        //    Console.SetCursorPosition(X, Y);
        //    Console.Write("X");
        //}

        //List<Move> IRenderable.GetMoves()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
