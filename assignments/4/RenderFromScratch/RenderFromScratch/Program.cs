using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderFromScratch
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
            List<IRenderable> renderables = new List<IRenderable>();

            Console.WriteLine("Enter desired Length of room (0-100): ");
            int roomLength = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter desired Width of room (0-100): ");
            int roomWidth = int.Parse(Console.ReadLine());
            Console.ReadLine();

            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            Table table = new Table();
            table.X = randomNumber;
            table.Y = randomNumber;

            Table table2 = new Table();
            table2.X = randomNumber;
            table2.Y = randomNumber;

            Chair chair = new Chair();
            chair.X = randomNumber;
            chair.Y = randomNumber;

            Room room = new Room();
            room.Length = roomLength;
            room.Width = roomWidth;

            renderables.Add(table);
            renderables.Add(table2);
            renderables.Add(chair);
            renderables.Add(room);

            Renderer render = new Renderer();
            render.Render(renderables);

            if (roomLength > 0 || roomWidth > 0)
            {
                Console.WriteLine();
                for (int y = 0; y < roomLength; y++)
                {
                    for (int x = 0; x < roomWidth; x++)
                    {
                        if (y == 0)
                        {
                            Console.Write("*");
                        }
                        else if (y == roomLength - 1)
                        {
                            Console.Write("*");
                        }
                        else if (x == 0)
                        {
                            Console.Write("*");
                        }
                        else if(x == roomWidth - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    Console.WriteLine();
                }
            }
    }


        public interface IRenderable
        {
            void Render();
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
        public class Room : IRenderable
        {
            public int Length { get; set; }
            public int Width { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(Length, Width);
                Console.Write('*');
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

    }

}

