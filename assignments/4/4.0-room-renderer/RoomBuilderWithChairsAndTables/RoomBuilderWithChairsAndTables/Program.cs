using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBuilderWithChairsAndTables
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

            List<Room> rooms = new List<Room>();
            for (int i = 0; i < 4; i++)
            {
                Room room = factory.Create();
                rooms.Add(room);
            }

            foreach (Room room in rooms)
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
                    Console.Write('X');
                    Console.WriteLine();
                }

                for (int col = 0; col < room.Width + 2; col++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();

                for (int j = 0; j < 2; j++)
                {
                    Table table = new Table();
                    table.X = random.Next(2, room.Width - 2);
                    table.Y = random.Next(2, room.Length + room.Length + room.Length);
                    renderables.Add(table);

                    Chair chair = new Chair();
                    chair.X = random.Next(2, room.Width - 2);
                    chair.Y = random.Next(2, room.Length + room.Length + room.Length);
                    renderables.Add(chair);

                }

            }

            Renderer render = new Renderer();
            render.Render(renderables);

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
                Length = Random.Next(8, 18)
            };

            return room;
        }
    }

    public class Room
    {
        public int Length { get; set; }
        public int Width { get; set; }
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

