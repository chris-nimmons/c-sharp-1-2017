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

                //generate room dimensions
                room.height = random.Next(10, 20);
                room.width = random.Next(10, 20);

                if (i == 0) //first room, act normal
                {
                    room.X = random.Next(0, 5);
                    room.Y = random.Next(0, 5);
                }
                else
                {
                    int directionOfNextRoomarino = random.Next(0, 1);
                    if (directionOfNextRoomarino == 0) //goes East
                    {
                        Room lastRoom = (Room)renderables.Last();
                        room.X = lastRoom.X + lastRoom.width;
                        room.Y = random.Next(10, 20);
                    }

                    
                    else // goes South
                    {
                        Room lastRoom = (Room)renderables.Last();
                        room.X = random.Next(10, 20);
                        room.Y = lastRoom.Y + lastRoom.height;
                    }
                }
                

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

    public class Table : IRenderable
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
        public int X { get; set; }
        public int Y { get; set; }
        public int height { get; set; }
        public int width { get; set; }

        public void Render()
        {

            for (int row = X+1; row < X + width; row++)
            {
                //top left corner to top right corner
                Console.SetCursorPosition(row, Y);
                Console.Write("X");
                //bottom left corner to bottom right corner
                Console.SetCursorPosition(row, Y + height);
                Console.Write("X");

            }

            for (int col = Y; col <= Y + height; col++)
            {
                //top left corner to bottom left corner
                Console.SetCursorPosition(X, col);
                Console.Write("X");
                //top right corner to bottom right corner
                Console.SetCursorPosition(X + width, col);
                Console.Write("X");

            }

            //debug help
            //Console.SetCursorPosition(X + 1, Y + 1);
            //Console.WriteLine("X: " + X + " Y: " + Y + " Width: " + width + " Height: " + height);
        }
    }

    public class Renderer
    {
        public void Render(List<IRenderable> renderables)
        {
            foreach (IRenderable renderable in renderables)
            {
                renderable.Render();
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
