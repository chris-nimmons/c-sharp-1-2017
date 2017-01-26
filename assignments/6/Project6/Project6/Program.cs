using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Program
    {
        static void Main(string[] args)
        {

            Renderer renderer = new Renderer();

            var cursor = new Cursor();

            Pawn pawn = new Pawn();
            Pawn one = new Pawn();
            King two = new King();
            Queen queen = new Queen();

            List<Piece> pieces = new List<Piece>();

            one.X = 4;
            one.Y = 0;

            two.X = 2;
            two.Y = 0;

            pawn.X = 1;
            pawn.Y = 0;

            queen.X = 3;
            queen.Y = 0;
            queen.Visible = true;

            pieces.Add(pawn);
            pieces.Add(one);
            pieces.Add(two);
            pieces.Add(queen);

            renderer.Render(pieces);

        }
    }
}
