using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class Renderer
    {
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public Renderer(int x, int y)
        {
            OffsetX = x;
            OffsetY = y;
        }

        public void Render(Piece[] pieces)
        {
            Console.SetCursorPosition(OffsetX, OffsetY);

            foreach (var piece in pieces)
            {
                Console.SetCursorPosition(piece.X + OffsetX, piece.Y + OffsetY);

                if (!piece.Taken)
                {
                    if (piece.Color == Color.White)
                    {
                        Console.Write(piece.Glyph);
                    }
                    else
                    {
                        Console.Write(piece.Glyph.ToString().ToLower());
                    }
                }
            }
        }

        public void HideSelection(Piece selection)
        {
            Console.SetCursorPosition(selection.X + OffsetX, selection.Y + OffsetY);
            Console.Write('o');
        }

        public void RenderMoves(List<Move> moves)
        {
            for (int m = 0; m < moves.Count; m++)
            {
                Console.SetCursorPosition(moves[m].X + OffsetX, moves[m].Y + OffsetY);

                if (moves[m].Takeable)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write('x');
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write('x');
                }
            }
        }
    }
}
