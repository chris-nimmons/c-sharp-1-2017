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
            Console.ReadLine();
            Console.Write("You're done!!! Press enter!");


        }

        public void Start()
        {
            List<IRenderable> renderables = new List<IRenderable>();

            Console.WriteLine("Enter desired Length of room (0-20): ");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Enter desired Width of room (0-20): ");
            int width = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine();

            Random random = new Random();
            int xoffset = random.Next(0, 20);
            int yoffset = random.Next(0, 20);

            Room room = new Room();
            room.Length = length;
            room.Width = width;
            room.xOffset = xoffset;
            room.yOffset = yoffset;

            Table table = new Table();
            Chair chair = new Chair();

            renderables.Add(room);
            renderables.Add(chair);
            renderables.Add(table);

            Renderer render = new Renderer();
            render.Render(renderables);

            Console.SetCursorPosition(xoffset + width, yoffset + length);

        }



        public interface IRenderable
        {
            void Render();
        }

        public class Table : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Length { get; set; }
            public int Width { get; set; }
            public int xOffset { get; set; }
            public int yOffset { get; set; }

            public void Render()
            {
                if (X <= Width && X >= (Width+xOffset)-1)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");
                }
                else if (Y <= Length && Y >= (Length + yOffset)-1) 
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("T");
                }
            }
        }
        public class Chair : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Length { get; set; }
            public int Width { get; set; }
            public int xOffset { get; set; }
            public int yOffset { get; set; }


            public void Render()
            {
                if (X <= Width && X >= (Width + xOffset) - 1)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");
                }
                else if (Y <= Length && Y >= (Length + yOffset) - 1)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("X");
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("C");
                }
            }
        }

        public class Room : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Length { get; set; }
            public int Width { get; set; }
            public int xOffset { get; set; }
            public int yOffset { get; set; }


            public void Render()
            {
                for (int x = xOffset; x < Width + xOffset; x++)
                {
                    for (int y = yOffset; y < Length + yOffset; y++)
                    {
                        Random value = new Random();
                        X = value.Next(1, 19);
                        Y = value.Next(1, 19);

                        Table table = new Table();
                        Chair chair = new Chair();
                        Table table1 = new Table();
                        Chair chair1 = new Chair();
                        Table table2 = new Table();
                        Chair chair2 = new Chair();
                        Table table3 = new Table();
                        Chair chair3 = new Chair();

                        if (x == xOffset || y == yOffset)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write('X');
                        }
                        else if (x == (Width + xOffset) - 1)
                        {

                            Console.SetCursorPosition(x, y);
                            Console.Write('X');
                        }
                        else if (y == (Length + yOffset) - 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write('X');
                        }
                        else
                        {
                            if (x != X && y != Y)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.SetCursorPosition(X, Y);
                                Console.Write('T');
                                Console.Write('C');
                                Console.SetCursorPosition(X, Y);
                                Console.Write('T');
                                Console.Write('C');
                                Console.SetCursorPosition(X, Y);
                                Console.Write('T');
                                Console.Write('C');
                                Console.SetCursorPosition(X, Y);
                                Console.Write('T');
                                Console.Write('C');

                            }

                        }

                    }
                }
                Console.ReadLine();
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