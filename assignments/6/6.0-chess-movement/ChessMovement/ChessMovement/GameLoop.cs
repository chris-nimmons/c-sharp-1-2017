using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessMovement
{
    public class GameLoop
    {
        public int moves;
        public GameBoard Board { get; set; }

        public void Start()
        {
            Board = new GameBoard();
            Board.Initialize();
            Board.State = new State(Board.TurnCount, Board.Pieces);
            Board.State.PopulateBoard();
            Piece selection = null;
            bool running = true;
            int turn = Board.TurnCount;

            var renderer = new Renderer(10, 5);
            renderer.Render(Board.Pieces);

            while (running)
            {
                while (turn == Board.TurnCount)
                {
                    int totalCurrentNodes = 0;
                    Board.State.BranchNode(0, 4, ref totalCurrentNodes, 0);

                    selection = Board.GetSelection(selection, renderer.OffsetX, renderer.OffsetY);

                    if (selection != null)
                    {
                        renderer.HideSelection(selection);
                        renderer.RenderMoves(Board.State.GetMoves(selection));
                    }
                    else
                    {
                        Console.Clear();
                        renderer.Render(Board.Pieces);
                    }
                }

                if (Board.TurnCount == -1)
                {
                    break;
                }
                turn++;
                renderer.Render(Board.Pieces);
            }
        }
    }
}