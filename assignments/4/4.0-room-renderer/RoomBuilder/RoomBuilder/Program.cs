using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
            Console.ReadLine();
        }


        public void Start()
        {

            Random random = new Random();
            List<IRenderable> renderables = new List<IRenderable>();

            
            Console.OutputEncoding = Encoding.GetEncoding(866);
            Console.WriteLine("┌───────────────────────────────────────────────────────────┐");

            int rows = random.Next(1, 10);
            int cols = random.Next(1, 15);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int nextrow = cols - col;
                    if (col + 1 > nextrow)
                    {
                        //Console.SetCursorPosition(rows, cols);
                        Console.WriteLine("│                                                           │");
                      
                    }
                    else
                    {
                        ;
                    }
                }
            }
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            Walls walls = new Walls();


            Table table = new Table();
            table.X = random.Next(2, 10);
            table.Y = random.Next(2, 10);

            Table table2 = new Table();
            table2.X = random.Next(2, 10);
            table2.Y = random.Next(2, 10);

            Chair chair = new Chair();
            chair.X = table.X - 1;
            chair.Y = table.Y;

            Chair chair2 = new Chair();
            chair2.X = table.X + 1;
            chair2.Y = table.Y;

            Chair chair3 = new Chair();
            chair3.X = table2.X - 1;
            chair3.Y = table2.Y;

            Chair chair4 = new Chair();
            chair4.X = table2.X + 1;
            chair4.Y = table2.Y;

            renderables.Add(table);
            renderables.Add(table2);

            renderables.Add(chair);
            renderables.Add(chair2);
            renderables.Add(chair3);
            renderables.Add(chair4);
            renderables.Add(walls);

            Renderer render = new Renderer();
            render.Render(renderables);

            // Console.SetCursorPosition(0,walls.rows+1);
            //Console.WriteLine("└───────────────────────────────────────────────────────────┘");
            Console.ReadLine();

        }


    }

    //Classes 

    public class Walls : IRenderable
    {
        public int rows { get; set; }
        public int cols { get; set; }

        public void Render()
        {
            //Console.SetCursorPosition(rows, cols);
            //Console.Write("│                                                           │");
        }
    }


    public class Table : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('T');
        }
    }

    public class Renderer
    {

        public Random Random { get; set; }

        public void Render(List<IRenderable> renderables)
        {
            foreach (IRenderable renderable in renderables)
            {
                renderable.Render();
            }

            Random = new Random();
            {
                int X = Random.Next(10, 30);
                int Y = Random.Next(10, 30);
                Console.SetCursorPosition(X, Y);
            }

        }
    }

    public interface IRenderable
    {
        void Render();
    }

    public class Chair : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('C');
        }
    }

}




