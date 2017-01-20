using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            Program program = new Program();
            program.Start();

            Console.ReadLine();
        }

        public void Start()
        {
            List<IRenderable> renderables = new List<IRenderable>();
            King king = new King();

            king.X = 0;
            king.Y = 0;
            king.Length = 3;
            king.Width = 3;

            renderables.Add(king);
            

            Pawn pawn = new Pawn();

            pawn.X = 0;
            pawn.Y = 0;
            pawn.Length = 2;

            renderables.Add(pawn);

            Bishop bishop = new Bishop();

            bishop.X = 10;
            bishop.Y = 10;
            bishop.Length = 10;
            
            renderables.Add(bishop);
            Console.Clear();

            Castle castle = new Castle();
            castle.X = 10;
            castle.Y = 10;
            castle.Length = 10;

            renderables.Add(castle);

            Queen queen = new Queen();
            queen.X = 10;
            queen.Y = 10;
            queen.Length = 10;

            renderables.Add(queen);

            Knight knight = new Knight();
            knight.X = 10;
            knight.Y = 10;
            knight.Length = 10;

            renderables.Add(knight);

            Renderer renderer = new Renderer();
            renderer.Render(renderables);
        }
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

    public interface IRenderable
    {
        int X { get; set; }
        int Y { get; set; }
        int Length { get; set; }
        int Width { get; set; }
        void Render();
    }
}
