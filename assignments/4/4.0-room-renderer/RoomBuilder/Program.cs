using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBuilder
{
    class Program
    {
        public bool Running { get; set; }
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

            {
                int width = random.Next(40,50);
                int height = random.Next(20,30);




                for (int x = 0; x <= width; x++)
                {
                    Console.SetCursorPosition(x, 0);
                    Console.Write("R");
                    Console.SetCursorPosition(x, height);
                    Console.Write("G");
                }
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("L");
                    Console.SetCursorPosition(width, y);
                    Console.Write("R");
                }
               
            }

            Table table = new Table();
            table.X = random.Next(2, 40);
            table.Y = random.Next(2, 30);

            Table table2 = new Table();
            table2.X = random.Next(2, 30);
            table2.Y = random.Next(2, 30);

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


            Renderer render = new Renderer();
            render.Render(renderables);



            Console.ReadLine();



            var program = new Program();
            program.Running = true;

            while (program.Running)
            {
                program.Running = false;
                {
                    Console.Clear();
                    Start();
                }
            }

        }


    }

    //Classes 


    public class Table : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('T');
            Console.ResetColor();
        }
    }

    public class Renderer
    {

        public Random Random { get; set; }

        int X { get; set; }
        int Y { get; set; }

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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('C');
            Console.ResetColor();
        }
    }

}




