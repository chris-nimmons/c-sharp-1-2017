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
            program.Start();
            Console.ReadLine();
            program.Start();
            Console.ReadLine();
            program.Start();
            Console.Write("You're done!!! Press enter!");


        }

        public void Start()
        {
            List<IRenderable> renderables = new List<IRenderable>();

            Console.WriteLine("Enter desired Length of room (0-100): ");
            int Length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter desired Width of room (0-100): ");
            int Width = int.Parse(Console.ReadLine());

            Console.ReadLine();

            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            Room room = new Room();
            room.positionX = randomNumber;
            room.positionY = randomNumber;
            room.Length = Length;
            room.Width = Width;

            Table table = new Table();
            table.X = randomNumber;
            table.Y = randomNumber;

            Table table2 = new Table();
            table2.X = randomNumber;
            table2.Y = randomNumber;

            Chair chair = new Chair();
            chair.X = randomNumber;
            chair.Y = randomNumber;

            renderables.Add(table);
            renderables.Add(table2);
            renderables.Add(chair);
            renderables.Add(room);

            Renderer render = new Renderer();
            render.Render(renderables);

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
            public int positionX { get; set; }
            public int positionY { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(positionX, positionY);
                    if (positionX > 0 && positionY > 0)
                    {
                        Console.WriteLine();
                        for (int y = 0; y < Length; y++)
                        {
                            for (int x = 0; x < Width; x++)
                            {
                                if (y == 0)
                                {
                                    Console.Write("*");
                                }
                                else if (y == Length - 1)
                                {
                                    Console.Write("*");
                                }
                                else if (x == 0)
                                {
                                    Console.Write("*");
                                }
                                else if (x == Width - 1)
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


