﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Board
    {

        private const int boardWidth = 8;
        private const int boardLength = 8;

        /// <summary>
        /// Chess board.
        /// </summary>
        private Piece[,] chessBoard = new Piece[8, 8];

        public Board()
        {

            PreLoadChessBoard();

            int width = boardWidth;
            int length = boardLength;

            DisplayChessBoardWithPieces(width, length);

        }

        private static void DisplayChessBoardWithPieces(int width, int length)
        {
            for (int i = 0; i < width ; i++)
            {

                for (int j = 0; j < length; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("X");
                }

            }
        }

        /// <summary>
        /// Sets up chess board with the initial position for the black and white pieces.
        /// </summary>
        private void PreLoadChessBoard()
        {

            SetPiece(new King() { X = 3, Y = 0 });
            SetPiece(new Queen() { X = 4, Y = 0 });
            SetPiece(new Bishop() { X = 2, Y = 0 });
            SetPiece(new Bishop() { X = 5, Y = 0 });
            SetPiece(new Knight() { X = 1, Y = 0 });
            SetPiece(new Castle() { X = 0, Y = 0 });
            SetPiece(new Knight() { X = 6, Y = 0 });
            SetPiece(new Castle() { X = 7, Y = 0 });
            SetPiece(new Pawn() { X = 0, Y = 1 });
            SetPiece(new Pawn() { X = 1, Y = 1 });
            SetPiece(new Pawn() { X = 2, Y = 1 });
            SetPiece(new Pawn() { X = 3, Y = 1 });
            SetPiece(new Pawn() { X = 4, Y = 1 });
            SetPiece(new Pawn() { X = 5, Y = 1 });
            SetPiece(new Pawn() { X = 6, Y = 1 });
            SetPiece(new Pawn() { X = 7, Y = 1 });

            SetPiece(new King() { X = 4, Y = 7 });
            SetPiece(new Queen() { X = 3, Y = 7 });
            SetPiece(new Bishop() { X = 2, Y = 7 });
            SetPiece(new Bishop() { X = 5, Y = 7 });
            SetPiece(new Knight() { X = 1, Y = 7 });
            SetPiece(new Castle() { X = 0, Y = 7 });
            SetPiece(new Knight() { X = 6, Y = 7 });
            SetPiece(new Castle() { X = 7, Y = 7 });
            SetPiece(new Pawn() { X = 0, Y = 6 });
            SetPiece(new Pawn() { X = 1, Y = 6 });
            SetPiece(new Pawn() { X = 2, Y = 6 });
            SetPiece(new Pawn() { X = 3, Y = 6 });
            SetPiece(new Pawn() { X = 4, Y = 6 });
            SetPiece(new Pawn() { X = 5, Y = 6 });
            SetPiece(new Pawn() { X = 6, Y = 6 });
            SetPiece(new Pawn() { X = 7, Y = 6 });

        }

        private void SetPiece(Piece piece)
        {
            chessBoard[piece.X, piece.Y] = piece;
        }
    }
}
