using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            List<Piece> pieces = new List<Piece>();
            
            Pawn pawn = new TicTacToe.Pawn();
            pawn.X = 4;
            pieces.Add(pawn);
            
            Pawn pawn2 = new Pawn();
            pawn2.X = 8;
            pieces.Add(pawn2);

            Queen queen = new TicTacToe.Queen();
            pieces.Add(queen);

            renderer.Render(pieces);
            Console.ReadLine();

        }

    }
}
