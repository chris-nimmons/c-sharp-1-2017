using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSet4
{
    public class Board
    {
        public List<IRenderable> Renderables { get; set; }

        public List<ChessPiece> chessPieces { get; set; }


        public Board()
        {
            chessPieces = new List<ChessPiece>();

            Renderables = new List<IRenderable>();

        }


        public void Initialize()
        {
            chessPieces = new List<ChessPiece>();

            Renderables = new List<IRenderable>();

            chessPieces.Add(new Knight() { X = 1, Y = 7 });
            chessPieces.Add(new Knight() { X = 6, Y = 7 });
            for (int pawnX = 0; pawnX <= 7; pawnX++)
            {
                chessPieces.Add(new Pawn() { X = pawnX, Y = 6 });
            }
            chessPieces.Add(new King() { X = 3, Y = 7 });
            chessPieces.Add(new Queen() { X = 4, Y = 7 });
            chessPieces.Add(new Rook() { X = 0, Y = 7 });
            chessPieces.Add(new Rook() { X = 7, Y = 7 });
            chessPieces.Add(new Bishop() { X = 2, Y = 7 });
            chessPieces.Add(new Bishop() { X = 5, Y = 7 });

            foreach (var chessPiece in chessPieces)
            {
                
                Renderables.Add(chessPiece);
                
                chessPiece.GetMoves();

                chessPiece.Visible = true;
            }

        }


        
    


    }
}


