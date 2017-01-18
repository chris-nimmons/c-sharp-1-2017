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

            //setting a new variable
            List<IRenderable> renderables = new List<IRenderable>();
            Table table = new Table();
            Table table2 = new Table();
            Table table3 = new Table();
            Table table4 = new Table();
            Table table5 = new Table();
            table.X = 2;
            table.Y = 1;

            table2.X = 9;
            table2.Y = 9;

            table3.X = 9;
            table3.Y = 1;

            table4.X = 2;
            table4.Y = 9;

            table5.X = random.Next(2, 9);
            table5.Y = random.Next(2, 9);


            renderables.Add(table);
            renderables.Add(table2);
            renderables.Add(table3);
            renderables.Add(table4);
            renderables.Add(table5);


            Chair chair = new Chair();
            chair.X = 4;
            chair.Y = 4;

            renderables.Add(chair);

            List<ISizeable> sizeable = new List<ISizeable>();
            Room room = new Room();
            sizeable.Add(room);


            string[] array1 = new string[7];
            array1[0] = "w";
            array1[1] = "w";
            array1[2] = "w";
            array1[3] = "w";
            array1[4] = "w";
            array1[5] = "w";
            array1[6] = "w";
            foreach (var data in array1)
            {
                Console.Write(data + " ");
            }

            room.Length = 10;

            for (int height = 0; height < room.Length; height++)
            {
                if (height == 6)
                {
                    Console.WriteLine("I");
                    Console.SetCursorPosition(12, height);
                    Console.WriteLine("I");

                }
                else
                {
                    Console.WriteLine("w");
                    Console.SetCursorPosition(12, height);
                    Console.WriteLine("x");
                   
                }
            }

            string[] array = new string[7];
            array[0] = "w";

            foreach (var data in array1)
            {
                Console.Write(data + " ");
            }

            

            Renderer renderer = new Renderer();
            //call the renderer method
            renderer.Render(renderables);
            renderer.Render(sizeable);
        }
    
    }
    
    public class Table : IRenderable
    {
        //properties need to be capitalized
        public int X { get; set; }

        public int Y { get; set; }

        //Render method goes here and this is it
        public void Render()
        {
            //this is able to run because of renderer class goes into start class
            Console.SetCursorPosition(X, Y);
            Console.Write("[]");
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

    public class Room : ISizeable
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public void Render()
        {
            return;
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
            }
        }
        public void Render(List<ISizeable> sizeables)
        {
            foreach (ISizeable sizeable in sizeables)
            {
                sizeable.Render();
                return;
            }
            
        }
    }
    public interface IRenderable
    {
        void Render();
    }

    public interface ISizeable
    {
        int Height { get; set; }
        int Length { get; set; }
        void Render();
    }
}
