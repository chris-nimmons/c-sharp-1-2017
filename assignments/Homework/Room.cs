using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendering
{
    class Program
    {
        static void Main()
        {
            //instance of start below to run start method
            Program program = new Program();
            program.Start();
           Console.ReadLine();
        }
        public void Start()
        {
            Random random = new Random();
            List<IRenderable> renderables = new List<IRenderable>();

            Room room = new Room();
            Room room1 = new Room();
            Room room2 = new Room();
            Room room3 = new Room();

            room.X = 1;
            room.Y = 1;
            room.Width = random.Next(10, 15);
            room.Length = random.Next(10, 15);
            room1.X = 20;
            room1.Y = 1;
            room1.Width = random.Next(10, 15);
            room1.Length = random.Next(10, 15);
            room2.X = 1;
            room2.Y = 20;
            room2.Width = random.Next(10, 15);
            room2.Length = random.Next(10, 15);
            room3.X = 20;
            room3.Y = 20;
            room3.Width = random.Next(10, 15);
            room3.Length = random.Next(10, 15);

            renderables.Add(room);
            renderables.Add(room1);
            renderables.Add(room2);
            renderables.Add(room3);

            //setting a new variable

            Table table = new Table();
            Table table1 = new Table();
            Table table2 = new Table();
            Table table3 = new Table();

            table.X = random.Next(4, 8);
            table.Y = random.Next(4, 9);
            table1.X = random.Next(21, 29);
            table1.Y = random.Next(4, 8);
            table2.X = random.Next(4, 8);
            table2.Y = random.Next(21, 29);
            table3.X = random.Next(21, 29);
            table3.Y = random.Next(21, 29);


            renderables.Add(table);
            renderables.Add(table1);
            renderables.Add(table2);
            renderables.Add(table3);

            Chair chair = new Chair();
            Chair chair1 = new Chair();
            Chair chair2 = new Chair();
            Chair chair3 = new Chair();
            chair.X = random.Next(4, 8);
            chair.Y = random.Next(4, 9);
            chair1.X = random.Next(21, 29);
            chair1.Y = random.Next(4, 8);
            chair2.X = random.Next(4, 8);
            chair2.Y = random.Next(21, 29);
            chair3.X = random.Next(21, 29);
            chair3.Y = random.Next(21, 29);

            renderables.Add(chair);
            renderables.Add(chair1);
            renderables.Add(chair2);
            renderables.Add(chair3);


            

            Renderer renderer = new Renderer();
            //call the renderer method
            renderer.Render(renderables);

        }
    
    }
    
    public class Table : IRenderable
    {
        //properties need to be capitalized
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        //Render method goes here and this is it
        public void Render()
        {
            //this is able to run because of renderer class goes into start class
            Console.SetCursorPosition(X, Y);
            Console.Write("[]");
            Console.ReadKey();

        }

    }

    

    public class Chair : IRenderable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("C");
            Console.ReadKey();
        }
    }

    public class Room : IRenderable
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public void Render()
        {
            for (int column = X; column <= X + Width; column++)
            {
                Console.SetCursorPosition(column, Y);
                Console.Write("w");
                Console.SetCursorPosition(column, Length + Y);
                Console.Write("w");
            }
            for (int row = Y; row <= Y + Length; row++)
            {
                Console.SetCursorPosition(X, row);
                Console.Write("w");
                Console.SetCursorPosition(Width + X, row);
                Console.Write("w");
            }
            Console.ReadKey();
        }
    }
    public class Renderer
    {

        //parameters go in parenthesis to method name
        public void Render(List<IRenderable> renderables)
        {
            //command to run render code in table class

            foreach (IRenderable renderable in renderables)
            {
                renderable.Render();
                Console.WriteLine();
            }
        }

    }
    public interface IRenderable
    {
        int Width { get; set; }
        int Length { get; set; }
        void Render();
    }

}
