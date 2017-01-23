using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRenderable> renderables = new List<IRenderable>();

            var chessset = new ChessSet();
            var pawn = new Pawn();

            renderables.Add(chessset);
            renderables.Add(pawn);
            Console.ReadLine();
        }

    

        }

        public interface IRenderable
        {
            void Render();
        }
        public class Renderer
        {
            public void Render(List<IRenderable> renderables)
            {
                foreach (IRenderable renderable in renderables)
                {
                    renderable.Render();
                }
            }
        }
}