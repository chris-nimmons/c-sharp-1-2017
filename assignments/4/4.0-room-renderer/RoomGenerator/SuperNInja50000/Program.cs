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

            RoomFactory factory = new RoomFactory();
            List<Room> rooms = new List<Room>();




            List<IRenderable> renderables = new List<IRenderable>();
            Table table = new Table();
            Table table2 = new Table();
            Table table3 = new Table();
            Chair chair = new Chair();
            Room room = new Room();
            //RNG totalRows = new RNG();


            table.X = random.Next(1, 20);
            table.Y = random.Next(1, 20);
            table2.X = random.Next(1, 20);
            table2.Y = random.Next(1, 20);
            table3.X = random.Next(1, 20);
            table3.Y = random.Next(1, 20);
            chair.X = random.Next(1, 20);
            chair.Y = random.Next(1, 20);
            //totalRows.totalRows = random.Next(10, 40);

            //room.Height = random.Next(1, 15);
            //room.Width = random.Next(1, 15);


            renderables.Add(table);
            renderables.Add(table2);
            renderables.Add(table3);
            renderables.Add(chair);
            renderables.Add(room);



            Renderer renderer = new Renderer();
            renderer.Render(renderables);
        }


        public class RoomFactory //: RNG

        /* This is a room generator
        {
            public Random random { get; set; }
            public RoomFactory()
            {
                random = new Random();
            }
            public Room Create()
            {

                Room room = new Room()
                {
                    Height = random.Next(8, 10),
                    Width = random.Next(10, 30),
                    Length = random.Next(10, 30),
                };

                return room;
            }
        }
        */
        {
            public RoomFactory()
            {
                Random random = new Random();


                int totalRows = random.Next(10, 40);

                /*
                int totalRows2 = random.Next(10, 40);
                int totalCols2 = random.Next(10, 40);
                int startRow2 = random.Next(10, 40);
                int startCol2 = random.Next(10, 40);
                */

                Console.WriteLine("Please press Enter to generate furniture.");

                for (int row = 0; row <= totalRows; row++)
                {
                    for (int col = 0; col <= totalRows; col++)
                    {
                        if (row == 0)
                        {
                            Console.Write('X');
                        }
                        else if (col == 0)
                        {
                            Console.Write("X");
                        }
                        else if (row == totalRows)
                        {
                            Console.Write('X');
                        }
                        else if (col == totalRows)
                        {
                            Console.Write('X');
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                /*
                for (int row2 = 0; row2 <= totalRows2; row2++)
                {
                    for (int col2 = 0; col2 <= totalCols2; col2++)
                    {
                        if (row2 == 0)
                        {
                            Console.Write('X');
                        }

                        else if (col2 == 0)
                        {
                            Console.Write('X');
                        }

                        else if (row2 == totalRows2)
                        {
                            Console.Write('X');
                        }

                        else if (col2 == totalCols2)
                        {
                            Console.Write('X');
                        }
                        else if (row2 == totalRows)
                        {
                            break;
                        }
                        else if (col2 == totalRows)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write('-');
                        }
                    }
                }
                Console.WriteLine();
                */

                Console.WriteLine("Please press Enter to generate furniture.");
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
            public int Height { get; set; }
            public int Width { get; set; }
            public void Render()
            {
            }
        }
        public class Renderer
        {
            public void Render(List<IRenderable> tables)
            {
                foreach (IRenderable table in tables)
                {
                    //this runs the Render method under public class Table above
                    //jumping around into differnt classes
                    table.Render();
                }
            }
        }

        /*
        public class RNG
        {
            public int totalRows { get; set; }
            public int totalRows2 { get; set; }
        }
        */


        // Interfaces /////////////////////////////////////////////////////////////////////////////////////////////
        public interface IRenderable
        {
            void Render();
            //this worked when Table under the list of renderable tables was changed to IRenderable
            //int X { get; set; }
            //int Y { get; set; }
        }
    }
}
