using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop();
            Console.ReadKey(true);
        }

        static void GameLoop()
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
                    selection = board.SelectionLoop(selection, renderer.OffsetX, renderer.OffsetY);

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
                turn++;
                renderer.Render(board.Pieces);
            }
        }
    }
}
