using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPieces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = true;

            var board = new Board();
            board.InitBoard();

            var program = new Program();
            program.GameLoop(board);

            Console.ReadKey(true);
        }

        public void GameLoop(Board board)
        {
            var renderer = new Renderer();
            Piece selection = null;
            bool running = true;
            int turn = board.TurnCount;
            renderer.Render(board);
            while (running)
            {
                renderer.RenderStats(board);
                while (turn == board.TurnCount)
                {
                    selection = board.SelectionLoop(selection);
                    if (selection != null)
                    {
                        renderer.RenderMove(board.CellsA[selection.X, selection.Y], board);
                    }
                    else
                    {
                        renderer.Render(board);
                    }
                }
                turn++;
                renderer.Render(board);
            }
        }

        public static void Testing(int x, int y)
        {
            //ChessPieces.Testing.MovementPatterns.HorizAndVertIterations(x, y);
            ChessPieces.Testing.MovementPatterns.DiagonalIterations(x, y);
        }
    }
}
