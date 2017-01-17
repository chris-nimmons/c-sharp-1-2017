using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();

        }

        public void Start()
        {
            Random random = new Random();

            List<IRenderable> renderables = new List<IRenderable>();

            Room previous = null;

            for (int i = 0; i < 5; i++)
            {
                Room room = new Room();
                room.Length = random.Next(10, 30);
                room.Width = random.Next(10, 30);
                if (previous != null)
                {
                    room.Y = (previous.Y + previous.Length + 2);
                }
                renderables.Add(room);

                for (int f = 0; f < 2; f++)
                {
                    Table table = new Table();
                    table.X = random.Next(room.X + 1, room.Width);
                    table.Y = random.Next(room.Y + 1, room.Y + room.Length);
                    renderables.Add(table);

                    Chair chair = new Chair();
                    chair.X = random.Next(room.X + 1, room.Width);
                    chair.Y = random.Next(room.Y + 1, room.Y + room.Length - 1);
                    renderables.Add(chair);

                    Dog dog = new Dog();
                    dog.X = random.Next(room.X + 1, room.Width);
                    dog.Y = random.Next(room.Y + 1, room.Y + room.Length - 1);
                    renderables.Add(dog);
                }

                previous = room;

            }
            Renderer renderer = new Renderer();
            renderer.Render(renderables);
            Console.ReadLine();
        }

        public class Room : IRenderable, ISizeable
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Length { get; set; }

            public void Render()
            {

                for (int columns = X; columns <= X + Width + 1; columns++)
                {
                    Console.SetCursorPosition(columns, Y);
                    Console.Write("X");

                    Console.SetCursorPosition(columns, Y + Length + 1);
                    Console.Write("X");
                }

                for (int row = Y; row <= Y + Length + 1; row++)
                {
                    Console.SetCursorPosition(X, row);
                    Console.Write("X");


                    Console.SetCursorPosition(X + Width + 1, row);
                    Console.Write("X");

                }

            }

            public class RoomRenderer
            {
                public void Render()
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

        public interface IRenderable
        {
            void Render();
        }

        public interface ISizeable
        {
            void Render();
        }

    }
}

