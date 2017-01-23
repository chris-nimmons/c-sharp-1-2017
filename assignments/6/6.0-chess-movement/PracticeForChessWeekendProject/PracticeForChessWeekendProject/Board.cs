using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeForChessWeekendProject
{
    class Board : Piece
    {



        public List<Piece> PlacePiece()
        {

            var pieces = new List<Piece>();

            var king = new King();
            king.Render();
            pieces.Add(king);

            var queen = new Queen();
            queen.Render();
            pieces.Add(queen);

            var knight = new Knight();
            knight.Render();
            pieces.Add(knight);

            var pawn = new Pawn();
            pawn.Render();
            pieces.Add(pawn);

            var bishop = new Bishop();
            bishop.Render();
            pieces.Add(bishop);

            var castle = new Castle();
            castle.Render();
            pieces.Add(castle);

            return pieces;

            //return PlacePiece();
        }


    }
}
