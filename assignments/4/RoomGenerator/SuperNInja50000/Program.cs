using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomGenerator
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
            //THIS IS ALL YOU NEED FOR RANDOM!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Random random = new Random();

            List<IRenderable> renderables = new List<IRenderable>();
           
            for (int i = 0; i <= 3; i++)
            {
                Room room = new Room();

                room.length = random.Next(20, 80);
                room.width = random.Next(20, 80);

                renderables.Add(room);
            }

            for (int t = 0; t < random.Next(1, 8); t++)
            {
                Table table = new Table();

                table.X = random.Next(1, 50);
                table.Y = random.Next(1, 50);

                renderables.Add(table);
            }

            for (int c = 0; c < random.Next(1, 8); c++)
            {
                Chair chair = new Chair();

                chair.X = random.Next(1, 50);
                chair.Y = random.Next(1, 50);

                renderables.Add(chair);
            }

            Renderer renderer = new Renderer();
            renderer.Render(renderables);

            Console.ReadLine();
        }
    }

    public class Table : Room, IRenderable
    { 

        public int X { get; set; }
        public int Y { get; set; }
        //Render method goes here
        //This is the render method
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            //if (X == )
            //{
            //break;
            //}
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
    public class Room : IRenderable
    {
        public int length { get; set; }
        public int width { get; set; }
        public void Render()
        {

            for (int x = 0; x <= length; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("X");

                Console.SetCursorPosition(x, width);
                Console.Write("X");

            }

            for (int y = 0; y <= width; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("X");

                Console.SetCursorPosition(length, y);
                Console.Write("X");
            }
        }
    }

    public class Renderer
    {
        public void Render(List<IRenderable> tables)
        {
            foreach (IRenderable table in tables)
            {
                table.Render();
                //this runs the Render method under public class Table above
                //jumping around into differnt classes
            }
        }
    }

    // Interfaces /////////////////////////////////////////////////////////////////////////////////////////////
    public interface IRenderable
    {
        void Render();
        //this worked when Table under the list of renderable tables was changed to IRenderable
        //int X { get; set; }
        //int Y { get; set; }
    }
}
