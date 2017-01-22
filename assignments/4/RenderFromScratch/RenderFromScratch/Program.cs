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
            Console.Clear();
            program.Start();
            Console.ReadLine();
            Console.Clear();
            program.Start();
            Console.ReadLine();
            Console.Clear();
            program.Start();
            Console.ReadLine();
            Console.Write("You're done!!! Press enter!");
            Console.ReadLine();
        }

        public void Start()
        {

            List<IRenderable> renderables = new List<IRenderable>();

            Dimensions dimensions = CreateDimensions();

            var table = new Table(dimensions);
            var chair = new Chair(dimensions);
            var room = new Room(dimensions);

            renderables.Add(room);
            renderables.Add(chair);
            renderables.Add(table);


            Renderer render = new Renderer();
            render.Render(renderables);

            Console.SetCursorPosition(dimensions.xOffset
                + dimensions.Width
                , dimensions.yOffset
                + dimensions.Length);
        }

        public interface IRenderable
        {
            void Render();
        }

        public class Dimensions
        {

            public int Length { get; set; }
            public int Width { get; set; }
            public int xOffset { get; set; }
            public int yOffset { get; set; }

        }

        public static Dimensions CreateDimensions()
        {

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

            var dimensions = new Dimensions
            {
                Length = length,
                Width = width,
                xOffset = xoffset,
                yOffset = yoffset
            };

            return dimensions;

        }



        public class Table : IRenderable
        {
            private Dimensions dimensions;

            public Table(Dimensions dimensions)
            {
                this.dimensions = dimensions;
            }

            public int X { get; set; }
            public int Y { get; set; }


            public void Render()
            {
                for (int X = this.dimensions.xOffset; X < this.dimensions.Width + this.dimensions.xOffset; X++)
                {
                    for (int Y = this.dimensions.yOffset; Y < this.dimensions.Length + this.dimensions.yOffset; Y++)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.Write('T');
                    }
                }
            }
        }

        public class Chair : IRenderable
        {
            private Dimensions dimensions;

            public Chair(Dimensions dimensions)
            {
                this.dimensions = dimensions;
            }

            public int X { get; set; }
            public int Y { get; set; }


            public void Render()
            {
                for (int X = this.dimensions.xOffset; X < this.dimensions.Width + this.dimensions.xOffset; X++)
                {
                    for (int Y = this.dimensions.yOffset; Y < this.dimensions.Length + this.dimensions.yOffset; Y++)
                    {
                        Console.SetCursorPosition(X, Y);
                        Console.Write('C');
                    }
                }
            }

        }

        public class Room : IRenderable
        {
            private Dimensions dimensions;

            public Room(Dimensions dimensions)
            {
                this.dimensions = dimensions;
            }

            public int X { get; set; }
            public int Y { get; set; }


            public void Render()
            {
                for (int X = this.dimensions.xOffset; X < this.dimensions.Width + this.dimensions.xOffset; X++)
                {
                    for (int Y = this.dimensions.yOffset; Y < this.dimensions.Length + this.dimensions.yOffset; Y++)
                    {
                        if (X == this.dimensions.xOffset || Y == this.dimensions.yOffset)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.Write('X');
                        }
                        else if (X == (this.dimensions.Width + this.dimensions.xOffset) - 1)
                        {

                            Console.SetCursorPosition(X, Y);
                            Console.Write('X');
                        }
                        else if (Y == (this.dimensions.Length + this.dimensions.yOffset) - 1)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.Write('X');
                        }
                        else
                        {

                            Console.SetCursorPosition(X, Y);
                            Console.Write(" ");

                        }
                    }
                }
            }
        }


            public class Renderer
            {
                public int X { get; set; }
                public int Y { get; set; }
                public int Length { get; set; }
                public int Width { get; set; }
                public int xOffset { get; set; }
                public int yOffset { get; set; }

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

