using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNInja50000
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

            //RoomFactory factory = new RoomFactory();
            //List<Room> rooms = new List<Room>();




            List<IRenderable> renderables = new List<IRenderable>();
            Table table = new Table();
            Table table2 = new Table();
            Table table3 = new Table();
            Chair chair = new Chair();
            Room room = new Room();
            Room2 room2 = new Room2();
            Room3 room3 = new Room3();
            Room4 room4 = new Room4();


            table.X = random.Next(1, 20);
            table.Y = random.Next(1, 20);
            table2.X = random.Next(1, 20);
            table2.Y = random.Next(1, 20);
            table3.X = random.Next(1, 20);
            table3.Y = random.Next(1, 20);
            chair.X = random.Next(1, 20);
            chair.Y = random.Next(1, 20);
            room.length = random.Next(20, 40);
            room.width = random.Next(20, 40);
            room2.length = random.Next(20, 20);
            room2.width = random.Next(20, 20);
            room3.length = random.Next(40, 60);
            room3.width = random.Next(20, 20);
            room4.length = random.Next(40, 80);
            room4.width = random.Next(20, 60);

            renderables.Add(table);
            renderables.Add(table2);
            renderables.Add(table3);
            renderables.Add(chair);
            renderables.Add(room);
            renderables.Add(room2);
            renderables.Add(room3);
            renderables.Add(room4);


            Renderer renderer = new Renderer();
            renderer.Render(renderables);

            Console.WriteLine("Thank you for rendering the room!");
            Console.ReadLine();
        }



    }




    public class Table : IRenderable //, RNG
    {
        public int X { get; set; }
        public int Y { get; set; }
        //Render method goes here
        //This is the render method
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            //if (X == totalRows)
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

    public class Room2 : IRenderable
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
            //Console.ReadLine();
        }
    }

    public class Room3 : IRenderable
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
            Console.ReadLine();
        }
    }

    public class Room4 : IRenderable

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
