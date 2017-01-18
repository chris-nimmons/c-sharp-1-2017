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

            Random random1 = new Random();
            int randomNumber1 = random1.Next(0, 100);

            Room room = new Room();
            room.positionX = randomNumber1;
            room.positionY = randomNumber1;
            room.Length = Length;
            room.Width = Width;

            Random random = new Random();
            int randomNumberW = random.Next(0, room.Width - 1);
            int randomNumberL = random.Next(0, room.Length - 1);

            Table table = new Table();
            table.X = randomNumberW;
            table.Y = randomNumberL;

            Table table2 = new Table();
            table2.X = randomNumberW;
            table2.Y = randomNumberL;

            Chair chair = new Chair();
            chair.X = randomNumberW;
            chair.Y = randomNumberL;


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
                            else if (x != 'T' && y != 'T')
                            {
                                Console.Write(" ");
                            }
                            else if (y != 'C' && x != 'C')
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                if (x != 'T' && y != 'T')
                                {
                                    Console.Write("T");
                                }
                                else
                                {
                                    Console.Write("C");
                                }

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


