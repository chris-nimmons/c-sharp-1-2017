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
            renderables.Add(table);
            renderables.Add(chair);

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

            public void Render()
            {
                if (X < 0 || Y < 0)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("");
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write('T');
                }
            }
        }
        public class Chair : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Render()
            {
                if (X < 0 || Y < 0)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("");
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write('C');
                }
            }
        }

        public class Room : IRenderable
        {
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
                            Random randomplace = new Random();
                            int randomx = randomplace.Next(1, 19);
                            int randomy = randomplace.Next(1, 19);
                            Console.SetCursorPosition(randomx, randomy);
                            Random randomchar = new Random();
                            char[] alpha = "TC   TC   TC   TC TC TC TC TC TC".ToCharArray();
                            int index = randomchar.Next(alpha.Length);
                            Console.Write(alpha[index]);
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