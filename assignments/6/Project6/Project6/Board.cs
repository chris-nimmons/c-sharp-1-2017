using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Board 
    {
        Pawn pawn = new Pawn();
        Cursor cursor = new Cursor();
        public bool playing = true;
        private const int boardWidth = 8;
        private const int boardLength = 8;
        /// <summary>
        /// Chess board.
        /// </summary>
        private Piece[,] chessBoard = new Piece[8, 8];

        private List<Piece> pieces;

        public Board()
        {
            PreLoadChessBoard();
        }

        public bool IsMoveAllowed()
        {

            return false;
        }

        public List<Piece> GetPieces()
        {

            var pieces = new List<Piece>();

            foreach (var piece in this.chessBoard)
            {
                if (piece != null)
                {
                    pieces.Add(piece);
                }
            }
            this.pieces = pieces;

            return pieces;

        }

        /// <summary>
        /// Determines if the move detected by the selected piece and to position is allowed.
        /// </summary>
        /// <param name="selectedPiece"></param>
        /// <param name="toPosition"></param>
        /// <returns>True if moved allowed for the piece, false means the piece does not move.</returns>
        /// 

        /// <summary>
        /// Sets up chess board with the initial position for the black and white pieces.
        /// </summary>
        private void PreLoadChessBoard() 
        {

            SetPiece(new King() { X = 3, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Queen() { X = 4, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Bishop() { X = 2, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Bishop() { X = 5, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Knight() { X = 1, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Castle() { X = 0, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Knight() { X = 6, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Castle() { X = 7, Y = 0, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 0, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 1, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 2, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 3, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 4, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 5, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 6, Y = 1, Color = Piece.PieceType.White });
            SetPiece(new Pawn() { X = 7, Y = 1, Color = Piece.PieceType.White });

            SetPiece(new King() { X = 4, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Queen() { X = 3, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Bishop() { X = 2, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Bishop() { X = 5, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Knight() { X = 1, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Castle() { X = 0, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Knight() { X = 6, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Castle() { X = 7, Y = 7, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 0, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 1, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 2, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 3, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 4, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 5, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 6, Y = 6, Color = Piece.PieceType.Black });
            SetPiece(new Pawn() { X = 7, Y = 6, Color = Piece.PieceType.Black });

        }

        private void SetPiece(Piece piece)
        {
            chessBoard[piece.X, piece.Y] = piece;
        }
    }
}