using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessmoves
{
    public class Board
    {
        public List<IRenderable> Renderable { get; set; }

        public Renderer Renderer { get; set; }

        public List<Piece> Pieces { get; set; }

        

        public Board()
        {
            Pieces = new List<Piece>();
            Renderable = new List<IRenderable>();
            
        }

        public void Initialize()
        {
            
            Pieces = new List<Piece>();
            Renderable = new List<IRenderable>();

            var king = new King() { X = 4, Y = 0 };
            Pieces.Add(king);

            var queen = new Queen() { X = 3, Y = 0 };
            Pieces.Add(queen);

            var bishop = new Bishop() { X = 2, Y = 0 };
            Pieces.Add(bishop);

            var knight = new Knight() { X = 1, Y = 0 };
            Pieces.Add(knight);

            var rook = new Rook() { X = 0, Y = 0 };
            Pieces.Add(rook);

            var pawn = new Pawn() { X = 0, Y = 1 };
            Pieces.Add(pawn);

            foreach (var piece in Pieces)
            {
                Renderable.Add(piece);
                piece.Visible = true;
            }
            
        }
    }
}
