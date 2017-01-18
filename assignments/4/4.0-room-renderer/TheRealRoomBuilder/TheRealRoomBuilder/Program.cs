using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRealRoomBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.CursorVisible = false;
            program.Start();
            Console.ReadLine();

        }

        public void Start()
        {
            Random random = new Random();
            List<IRenderable> renderables = new List<IRenderable>();

            RoomFactory factory = new RoomFactory();

            Room previous = null;
            List<Room> rooms = new List<Room>();

            for (int i = 0; i < 4; i++)
            {

                Room room = factory.Create();
                rooms.Add(room);
                renderables.Add(room);

                if (previous != null)
                {
                    room.Y = (previous.Y + previous.Length + 3);
                }


                for (int j = 0; j < 2; j++)
                {
                    Table table = new Table();
                    table.X = random.Next(room.X + 1, room.Width - 1);
                    table.Y = random.Next(room.Y + 1, room.Y + room.Length);
                    renderables.Add(table);

                    Chair chair = new Chair();
                    chair.X = random.Next(room.X + 1, room.Width - 1);
                    chair.Y = random.Next(room.Y + 1, room.Y + room.Length);
                    renderables.Add(chair);

                    Poop poop = new Poop();
                    poop.X = random.Next(room.X + 1, room.Width - 1);
                    poop.Y = random.Next(room.Y + 1, room.Y + room.Length);
                    renderables.Add(poop);

                }
                previous = room;

                Renderer render = new Renderer();

                render.Render(renderables);
            }

        }
    }

    public class RoomFactory
    {
        public Random Random { get; set; }

        public RoomFactory()
        {
            Random = new Random();
        }

        public Room Create()
        {

            Room room = new Room()
            {
                Width = Random.Next(8, 18),
                Length = Random.Next(8, 18),

                X = 0,
                Y = 0,
            };

            return room;
        }
    }

    public class Room : IRenderable
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Render()
        {
            for (int col = X; col <= X + Width + 2; col++)
            {
                Console.SetCursorPosition(col, Y);
                Console.Write("X");

                Console.SetCursorPosition(col, Y + Length + 2);
                Console.Write("X");
            }

            for (int row = Y; row <= Y + Length + 2; row++)
            {
                Console.SetCursorPosition(X, row);
                Console.Write("X");

                Console.SetCursorPosition(X + Width + 2, row);
                Console.Write("X");
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

    public class Poop : IRenderable
    {
        public int X { get; set; }

        public int Y { get; set; }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('P');
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

}

