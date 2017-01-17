using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
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

            for (int i = 0; i < 1; i++)
            {
                Room room = new Room();
                room.Length = random.Next(10, 30);
                room.Width = random.Next(10, 30);
                renderables.Add(room);

                //Renderer renderer = new Renderer();
                //renderer.Render(renderables);

            }
            foreach (Room room in renderables)
            {
                for (int col = 0; col < room.Width + 2; col++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();

                for (int row = 0; row < room.Length; row++)
                {
                    Console.Write("X");

                    for (int col = 0; col < room.Width; col++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write("X");
                    Console.WriteLine();
                }

                for (int col = 0; col < room.Width + 2; col++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }


            for (int i = 0; i < 2; i++)
            {

                Table table = new Table();
                // table.X = (5);
                //table.Y = (6);
                table.X = random.Next(1, 14);
                table.Y = random.Next(1, 14);
                renderables.Add(table);



                //for (int c = 0; c < 6; c++)
                //{

                Chair chair = new Chair();
                //chair.X = (5);
                //chair.Y = (6);
                chair.X = (table.X);
                chair.Y = (table.Y + 1);
                renderables.Add(chair);

                Chair2 chair2 = new Chair2();
                chair2.X = (table.X + 1);
                chair2.Y = (table.Y + 1);
                renderables.Add(chair2);


            }

            for (int i = 0; i < 1; i++)
            {
                Dog dog = new Dog();
                dog.X = random.Next(1, 20);
                dog.Y = random.Next(1, 20);
                renderables.Add(dog);
            }

            Renderer renderer = new Renderer();
            renderer.Render(renderables);

        }

        public class Room : IRenderable, ISizeable
        {
            public int Width { get; set; }
            public int Length { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(Width, Length);

                //Console.Write("X");
            }

            public class RoomRenderer
            {
                public void Render(IRenderable renderable)
                {


                }
            }
        }

        public class Table : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("TT");
            }
        }

        public class Chair : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("C");
            }
        }
        public class Chair2 : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("C");
            }
        }

        public class Dog : IRenderable
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Render()
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("D");

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

        public interface ISizeable
        {
            int Width { get; set; }
            int Length { get; set; }
        }

        public interface IRenderable
        {
            void Render();
        }

    }
}
