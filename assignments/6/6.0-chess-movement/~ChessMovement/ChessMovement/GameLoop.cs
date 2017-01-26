using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class GameLoop
    {
        public void Start()
        {
            var board = new Board();
            board.InitAllPieces();
            Piece selection = null;
            bool running = true;
            int turn = board.TurnCount;

            var renderer = new Renderer(10, 5);
            renderer.Render(board.Pieces);

            while (running)
            {
                while (turn == board.TurnCount)
                {
                    selection = board.GetSelection(selection, renderer.OffsetX, renderer.OffsetY);

                    if (selection != null)
                    {
                        renderer.HideSelection(selection);
                        renderer.RenderMoves(selection.GetMoves());
                    }
                    else
                    {
                        Console.Clear();
                        renderer.Render(board.Pieces);
                    }
                }

                if (board.TurnCount == -1)
                {
                    break;
                }
                turn++;
                renderer.Render(board.Pieces);
            }
        }
    }
}